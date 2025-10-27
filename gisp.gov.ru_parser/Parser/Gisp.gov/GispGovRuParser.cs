using gisp.gov.ru_parser.Helpers;
using gisp.gov.ru_parser.Models.ApiModels;
using gisp.gov.ru_parser.Models.Configs;
using gisp.gov.ru_parser.Models.ProductModels;
using gisp.gov.ru_parser.Models.RequestModels;
using gisp.gov.ru_parser.Parser.Loader;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace gisp.gov.ru_parser.Parser.Gisp.gov
{
    public class GispGovRuParser
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GispGovRuConfig _config;
        public GispGovRuParser(
            IHttpClientFactory httpClientFactory, 
            IOptions<GispGovRuConfig> options,
            IHtmlLoader htmlLoader) 
        {
            _httpClientFactory = httpClientFactory;
            _config = options.Value;
        }

        public async Task<SearchResponse> GetProducts(SearchRequest request, CancellationToken cancellationToken)
        {
            var obj = new GispGovRuRequest(request.SearchPhraseList.First());

            using var client = _httpClientFactory.CreateClient();

            var req = new HttpRequestMessage(HttpMethod.Post, _config.Url);
            req.Content = new StringContent(JsonConvert.SerializeObject(obj));
            req.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var resp = await client.SendAsync(req ,cancellationToken);

            var str = await resp.Content.ReadAsStringAsync(cancellationToken);
            var model = JsonConvert.DeserializeObject<GispGovRuResponse>(str);

            var res = new SearchResponse() 
            {
                Variants = [new() 
                {
                    Phrase = request.SearchPhraseList.First(),
                    Products = []
                }]};

            foreach (var item in model.Items)
            {
                res.Variants.First().Products.Add(new()
                {
                    Link = item.ProductGispUrl,
                    Code = item.ProductOkpd2,
                    Name = item.ProductName,
                    Price = 0,
                    PriceCurrency = "RUB"
                });
            }

            return res;
        }

        public async Task<DetailsResponse> GetDetails(DetailsRequest detailsRequest, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(detailsRequest.ProductLinks.FirstOrDefault()))
            {
                return new() { Products = [] };
            }

            var prodId = Regex.Match(detailsRequest.ProductLinks.First(), @"[0-9]+$");

            using var client = _httpClientFactory.CreateClient();

            var req = new HttpRequestMessage(HttpMethod.Get, "https://gisp.gov.ru/mapm/api/product-detail/" + prodId);
            req.Headers.Add("Referer", "https://gisp.gov.ru/goods/");
            req.Headers.Add("Accept", "application/json, text/plain, */*");
            var resp = await client.SendAsync(req, cancellationToken);
            var str = await resp.Content.ReadAsStringAsync(cancellationToken);
            var model = JsonConvert.DeserializeObject<GispGovRuDetails>(str);

            var res = new DetailsResponse()
            {
                Products = []
            };

            res.Products.Add(new()
            {
                Code = model.Okpd2.Code,
                Link = detailsRequest.ProductLinks.First(),
                Name = model.Name,
                Price = 0,
                PriceCurrency = "RUB",
                Properties = GetProps(model)
            });

            return res;
        }

        private List<Property> GetProps(GispGovRuDetails gispGovRuDetails)
        {
            var res = new List<Property>();

            try
            {
                foreach (var item in ReflectionHelper.GetAllPropertyValues(gispGovRuDetails).Where(x => x.Value != null && x.Value.ToString() != ""))
                {
                    res.Add(new()
                    {
                        Name = item.Key,
                        Value = item.Value.ToString()
                    });
                }
            }
            catch (Exception ex) { }

            return res;
        }
    }
}

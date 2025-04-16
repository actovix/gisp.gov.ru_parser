using AngleSharp.Dom;
using gisp.gov.ru_parser.Helpers;
using gisp.gov.ru_parser.Models.ApiModels;
using gisp.gov.ru_parser.Models.Configs;
using gisp.gov.ru_parser.Models.ProductModels;
using gisp.gov.ru_parser.Models.RequestModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace gisp.gov.ru_parser.Parser.GosZakupki
{
    public class GosZakupkiParser
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GosZakupkiConfig _gosZakupkiConfig;

        public GosZakupkiParser(IHttpClientFactory httpClientFactory, IOptions<GosZakupkiConfig> gosZakupkiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _gosZakupkiConfig = gosZakupkiConfig.Value;
        }

        public async Task<SearchResponse> GetProducts(SearchRequest request, CancellationToken cancellationToken)
        {
            var obj = JsonConvert.SerializeObject(new GosZakupkiRequestBody(request.SearchPhraseList.First()));

            using var client = _httpClientFactory.CreateClient();

            var req = new HttpRequestMessage(HttpMethod.Post, _gosZakupkiConfig.Url)
            {
                Content = new StringContent(obj)
            };
            req.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            var resp = await client.SendAsync(req, cancellationToken);

            var str = await resp.Content.ReadAsStringAsync(cancellationToken);
            var model = JsonConvert.DeserializeObject<GosZakupkiItem>(str);

            var res = new SearchResponse()
            {
                Variants = [new() {
                    Phrase = request.SearchPhraseList.First(),
                    Products = []
                }]
            };

            foreach (var item in model.Result)
            {
                res.Variants.First().Products.Add(new()
                {
                    Name = item.GoodsName,
                    Code = new(item.Id.Oid.Take(20).ToArray()),
                    Link = "https://goszakupki.eaeunion.org/erpt/registers/vipiska/" + item.Id.Oid,
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

            var oid = Regex.Match(detailsRequest.ProductLinks.First(), @"[^/]+$");
            var obj = $"{{\"_id\":\"{oid}\"}}";

            using var client = _httpClientFactory.CreateClient();

            var req = new HttpRequestMessage(HttpMethod.Post, _gosZakupkiConfig.Url);
            req.Content = new StringContent(obj);
            req.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            var resp = await client.SendAsync(req, cancellationToken);

            var str = await resp.Content.ReadAsStringAsync(cancellationToken);
            var model = JsonConvert.DeserializeObject<GosZakupkiItem>(str).Result.First();

            var res = new DetailsResponse()
            {
                Products = []
            };

            res.Products.Add(new()
            {
                Link = detailsRequest.ProductLinks.First(),
                Name = model.GoodsName,
                Code = new(model.Id.Oid.Take(20).ToArray()),
                Price = 0,
                PriceCurrency = "RUB",
                Properties = GetProps(model),
            });

            return res;
        }

        private List<Property> GetProps(ResultItem model)
        {
            var res = new List<Property>();

            var coll = ReflectionHelper.GetAllPropertyValues(model).Where(x => x.Value != null && x.Value.ToString() != "");

            res.Add(new()
            {
                Name = "Company.Name",
                Value = model.Name
            });

            foreach (var item in coll)
            {
                res.Add(new()
                {
                    Name = item.Key,
                    Value = item.Value.ToString()
                });
            }

            return res;
        }
    }
}

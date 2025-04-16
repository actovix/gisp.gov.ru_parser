using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using gisp.gov.ru_parser.Helpers;
using gisp.gov.ru_parser.Models.ApiModels;
using gisp.gov.ru_parser.Models.Configs;
using gisp.gov.ru_parser.Models.ProductModels;
using gisp.gov.ru_parser.Models.RequestModels;
using gisp.gov.ru_parser.Parser.Loader;
using Microsoft.Extensions.Options;

namespace gisp.gov.ru_parser.Parser.ReestrDigitalGovRu
{
    public class ReestrDigGovRuParser
    {
        private readonly ReestrDigitalGovRuConfig _config;
        private readonly IHtmlLoader _htmlLoader;

        public ReestrDigGovRuParser(IOptions<ReestrDigitalGovRuConfig> options, IHtmlLoader htmlLoader)
        {
            _config = options.Value;
            _htmlLoader = htmlLoader;
        }

        public async Task<SearchResponse> GetProducts(SearchRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.SearchPhraseList.FirstOrDefault()))
            {
                return new();
            }

            var url = _config.Url.Replace("{query}", request.SearchPhraseList.FirstOrDefault());

            var resp = await _htmlLoader.LoadPageByLink(url, cancellationToken);

            if (string.IsNullOrEmpty(resp))
            {
                return new();
            }

            var htmlElem = await new HtmlParser().ParseDocumentAsync(resp, cancellationToken);

            var res = new SearchResponse()
            {
                Variants = [new() {
                    Phrase = request.SearchPhraseList.First(),
                    Products = []
                }]
            };

            foreach (var item in htmlElem.QuerySelectorAll(".item.collection-item.a-link"))
            {
                res.Variants.First().Products.Add(new()
                {
                    Code = "-",
                    Link = "https://reestr.digital.gov.ru" + item.GetAttribute("data-href") ?? "",
                    Name = item.GetAttribute<string>("div[data-name='Наименование']") ?? "",
                    Price = 0,
                    PriceCurrency = "RUB"
                });
            }

            return res;
        }
        public async Task<DetailsResponse> GetDetails(DetailsRequest detailsRequest, CancellationToken cancellationToken)
        {
            var url = detailsRequest.ProductLinks.FirstOrDefault();

            if (string.IsNullOrEmpty(detailsRequest.ProductLinks.FirstOrDefault()))
            {
                return new();
            }

            var resp = await _htmlLoader.LoadPageByLink(url, cancellationToken);

            var htmlELem = await new HtmlParser().ParseDocumentAsync(resp, cancellationToken);
            var e = htmlELem.QuerySelector("body");

            var res = new DetailsResponse()
            {
                Products = [new() {
                    Code = "-",
                    Link = url,
                    Price = 0,
                    PriceCurrency = "RUB",
                    Name = e.GetAttribute<string>(".page-title") ?? "",
                    Properties = GetProps(e)
                }]
            };

            return res;
        }

        private List<Property> GetProps(IElement elem)
        {
            var res = new List<Property>();

            var labels = elem.QuerySelectorAll(".form-label");

            foreach (var item in labels)
            {
                if (item.Text().Equals("Идентификационный номер (ИНН)"))
                {
                    var div = item.NextElementSibling;
                    res.Add(new()
                    {
                        Name = "Company.Inn",
                        Value = div.Text() ?? ""
                    });
                }
                if (item.Text().Equals("Полное наименование (коммерческая организация без преобладающего иностранного участия)"))
                {
                    var div = item.NextElementSibling;
                    res.Add(new()
                    {
                        Name = "Company.Name",
                        Value = div.Text() ?? ""
                    });
                }
                if (item.Text().Equals("Основной государственный регистрационный номер"))
                {
                    var div = item.NextElementSibling;
                    res.Add(new()
                    {
                        Name = "Company.Ogrn",
                        Value = div.Text() ?? ""
                    });
                }
            }

            var otherProps = elem.QuerySelectorAll(".tabs-content div:has(label)");
            foreach (var item in otherProps)
            {
                res.Add(new()
                {
                    Name = item.GetAttribute<string>("label") ?? "",
                    Value = item.GetAttribute<string>("div") ?? ""
                });
            }

            return res;
        }

    }
}

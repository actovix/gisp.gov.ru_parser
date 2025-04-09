using gisp.gov.ru_parser.Models.ApiModels;
using gisp.gov.ru_parser.Parser.Loader;
using System.Text;
using System.Web;

namespace gisp.gov.ru_parser.Parser;

public class ParserBase
{
    protected readonly IHtmlLoader _htmlLoader;
    protected readonly Serilog.ILogger _logger;

    public ParserBase(IHtmlLoader htmlLoader, Serilog.ILogger logger)
    {
        _htmlLoader = htmlLoader;
        _logger = logger;
    }

    public async Task<DetailsResponse> GetDetails(DetailsRequest detailsRequest, HtmlPageBase details, CancellationToken cancellationToken)
    {
        string url = detailsRequest.ProductLinks.First();
        var res = new DetailsResponse()
        {
            App = detailsRequest.App,
        };

        try
        {
            var html = await _htmlLoader.LoadPageByLink(url, cancellationToken);

            if (string.IsNullOrEmpty(html))
            {
                _logger.Information($"Html is null or empty: {url}");
                return res;
            }

            await details.TryParse(html);
            var dts = await details.GetDetails();

            res.Products = dts;
        }
        catch (Exception ex)
        {
            _logger.Information($"Error (can't) while downloading html from: {url}\n{ex.Message}");

        }

        return res;
    }

    public async Task<SearchResponse> GetProducts(SearchRequest searchRequest, string url, HtmlPageBase search, CancellationToken cancellationToken)
    {
        string finUrl = url.Replace("{query}", searchRequest.SearchPhraseList.First());
        var res = new SearchResponse()
        {
            App = searchRequest.App,
            Variants = new()
        };

        try
        {
            var html = await _htmlLoader.LoadPageByLink(finUrl, cancellationToken);

            if (string.IsNullOrEmpty(html))
            {
                _logger.Information($"Html is null or empty: {finUrl}");
                return res;
            }

            await search.TryParse(html);

            var prods = await search.GetProducts();
            res.Variants.Add(new()
            {
                Phrase = searchRequest.SearchPhraseList.First(),
                Products = prods
            });


        }
        catch (System.Exception ex)
        {
            _logger.Information($"Error (can't) while downloading html from: {finUrl}\n{ex.Message}");
        }

        return res;
    }

    public async Task<SearchResponse> GetProductsWithWinEncoding(SearchRequest searchRequest, string url, HtmlPageBase search, CancellationToken cancellationToken)
    {
        var unicQuery = searchRequest.SearchPhraseList.First();

        var winEnc = Encoding.GetEncoding("windows-1251");

        var winQuery = HttpUtility.UrlEncode(unicQuery, winEnc);

        string finUrl = url.Replace("{query}", winQuery);


        var res = new SearchResponse()
        {
            App = searchRequest.App,
            Variants = new()
        };

        try
        {
            var html = await _htmlLoader.LoadPageByLink(finUrl, cancellationToken);

            if (string.IsNullOrEmpty(html))
            {
                _logger.Information($"Html is null or empty: {finUrl}");
                return res;
            }

            await search.TryParse(html);

            var prods = await search.GetProducts();
            res.Variants.Add(new()
            {
                Phrase = searchRequest.SearchPhraseList.First(),
                Products = prods
            });


        }
        catch (System.Exception ex)
        {
            _logger.Information($"Error (can't) while downloading html from: {finUrl}\n{ex.Message}");
        }

        return res;
    }
}

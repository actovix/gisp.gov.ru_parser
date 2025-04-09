using gisp.gov.ru_parser.Models.ApiModels;
using gisp.gov.ru_parser.Models.Configs;
using Microsoft.Extensions.Options;

namespace gisp.gov.ru_parser.Parser;

public class ParserLinker<Config, HtmlPage>
    where Config : ConfigBase
    where HtmlPage : HtmlPageBase, new()
{
    private readonly ParserBase _parser;
    private readonly ConfigBase _config;

    public ParserLinker(ParserBase parser, IOptions<Config> conf)
    {
        _config = conf.Value;
        _parser = parser;
    }

    public async Task<DetailsResponse> GetDetails(DetailsRequest detailsRequest, CancellationToken cancellationToken)
    {
        var res = await _parser.GetDetails(detailsRequest, new HtmlPage(), cancellationToken);
        if (res.Products.Any())
            res.Products.First().Link = detailsRequest.ProductLinks.First();

        return res;
    }

    public async Task<SearchResponse> GetProducts(SearchRequest searchRequest, CancellationToken cancellationToken)
    {
        if (_config.IsWindowsEncodedPage)
            return await _parser.GetProductsWithWinEncoding(searchRequest, _config.Url, new HtmlPage(), cancellationToken);
        return await _parser.GetProducts(searchRequest, _config.Url, new HtmlPage(), cancellationToken);
    }
}

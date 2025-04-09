using gisp.gov.ru_parser.Models.ApiModels;

namespace gisp.gov.ru_parser.Parser;

public interface IParser
{
    public Task<SearchResponse> GetProducts(SearchRequest searchRequest, CancellationToken cancellationToken);
    public Task<DetailsResponse> GetDetails(DetailsRequest detailsRequest, CancellationToken cancellationToken);
}
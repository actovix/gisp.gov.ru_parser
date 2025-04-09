using gisp.gov.ru_parser.Models.AuthModels;
using gisp.gov.ru_parser.Models.ProductModels;

namespace gisp.gov.ru_parser.Models.ApiModels;

public class SearchResponse : ApiKey
{   
    public List<Variant> Variants { get; set; } = new();
}

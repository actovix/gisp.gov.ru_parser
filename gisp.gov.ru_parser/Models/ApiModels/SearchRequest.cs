using gisp.gov.ru_parser.Models.AuthModels;
using System.ComponentModel.DataAnnotations;

namespace gisp.gov.ru_parser.Models.ApiModels;

public class SearchRequest : ApiKeys
{
    [Required]
    public string[] SearchPhraseList { get; set; } = [];

    public int WaitTimeout { get; set; } = 1000;
    
    public int MaxProductsCount { get; set; } = 25;
}

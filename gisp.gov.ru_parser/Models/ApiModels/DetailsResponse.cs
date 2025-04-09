using System.ComponentModel.DataAnnotations;
using gisp.gov.ru_parser.Models.AuthModels;
using gisp.gov.ru_parser.Models.ProductModels;

namespace gisp.gov.ru_parser.Models.ApiModels;

public class DetailsResponse : ApiKey
{
    [Required]
    public List<ProductDetails> Products { get; set; } = new();
}
using System.ComponentModel.DataAnnotations;

namespace gisp.gov.ru_parser.Models.ProductModels;

public class Variant
{
    [Required]
    public string Phrase { get; set; } = "";
    
    [Required]
    public List<Product> Products { get; set; } = [];
}

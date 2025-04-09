using System.ComponentModel.DataAnnotations;
using gisp.gov.ru_parser.Models.AuthModels;

namespace gisp.gov.ru_parser.Models.ApiModels;

public class DetailsRequest : ApiKey
{
    [Required]
    public bool CanLoadAttachments { get; set; } = false;
    
    [Required]
    public List<string> ProductLinks { get; set; } = [];
}

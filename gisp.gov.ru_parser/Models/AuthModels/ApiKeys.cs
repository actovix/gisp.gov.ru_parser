using System.ComponentModel.DataAnnotations;

namespace gisp.gov.ru_parser.Models.AuthModels;

public class ApiKeys
{
    [Required]
    public App App { get; set; } = new App();
}

public static class ApiKeysComparator
{
    public static bool IsEqual(this ApiKeys a, ApiKeys b)
    {
        if (a == null || b == null)
        {
            return false;
        }
        
        return a.App.AppId == b.App.AppId 
            && a.App.AppSecret == b.App.AppSecret;
    }
}
using System.ComponentModel.DataAnnotations;

namespace gisp.gov.ru_parser.Models.AuthModels;

public class ApiKey

{
    [Required]
    public App App { get; set; } = new();
}

public class ApiKeys
{
    [Required]
    public App[] app { get; set; } = [];
}

public static class ApiKeysComparator
{
    public static bool IsEqual(this App a, App b)
    {
        if (a == null || b == null)
        {
            return false;
        }
        
        return a.AppId == b.AppId 
            && a.AppSecret == b.AppSecret;
    }
}
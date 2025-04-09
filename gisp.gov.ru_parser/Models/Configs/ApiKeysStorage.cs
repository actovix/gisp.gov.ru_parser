using gisp.gov.ru_parser.Models.AuthModels;

namespace gisp.gov.ru_parser.Models.Configs;

public class ApiKeysStorage
{
    public Dictionary<string, ApiKeys> Keys { get; set; } = new();
}

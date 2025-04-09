using Newtonsoft.Json;

namespace gisp.gov.ru_parser.Models.RequestModels
{
    public class GosZakupkiRequestBody
    {
        public GosZakupkiRequestBody(string phrase)
        {
            And = [new()];
            And.First().Or = [];

            var tmp = And.First().Or;

            tmp.AddRange([
                new RegistryNumber(phrase),
                new Name(phrase),
                new Address(phrase),
                new IdentityCode(phrase),
                new GosZTnved(phrase),
                new GoodsOkpd2(phrase),
                new GoodsName(phrase)]);
        }

        [JsonProperty("$and")]
        public List<AndCondition> And { get; set; }
    }

    public class AndCondition
    {

        [JsonProperty("$or")]
        public List<object> Or { get; set; } = [];
    }

    public class RegistryNumber(string phrase)
    {
        [JsonProperty("registrynumber")]
        public OptReg OptReg { get; set; } = new(phrase);
    }

    public class Name(string phrase)
    {
        [JsonProperty("name")]
        public OptReg OptReg { get; set; } = new(phrase);
    }

    public class Address(string phrase)
    {
        [JsonProperty("address")]
        public OptReg OptReg { get; set; } = new(phrase);
    }

    public class IdentityCode(string phrase)
    {
        [JsonProperty("identitycode")]
        public OptReg OptReg { get; set; } = new(phrase);
    }

    public class GosZTnved(string phrase)
    {
        [JsonProperty("tnved")]
        public OptReg OptReg { get; set; } = new(phrase);
    }

    public class GoodsOkpd2(string phrase)
    {
        [JsonProperty("goodsokpd2")]
        public OptReg OptReg { get; set; } = new(phrase);
    }

    public class GoodsName(string phrase)
    {
        [JsonProperty("goodsname")]
        public OptReg OptReg { get; set; } = new(phrase);
    }

    public class OptReg(string phrase)
    {
        [JsonProperty("$regex")]
        public string Regex { get; set; } = phrase;

        [JsonProperty("$options")]
        public string Options { get; set; } = "i";
    }
}
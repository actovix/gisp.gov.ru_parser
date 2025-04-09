using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace gisp.gov.ru_parser.Models.RequestModels
{
    public class GispGovRuRequest
    {
        public GispGovRuRequest(string searchPhrase)
        {
            Opt = new();

            var prod_reg_num = (Opt.Filter[0] as object[])[0] as object[];
            prod_reg_num[2] = searchPhrase;

            var prod_name = (Opt.Filter[0] as object[])[2] as object[];
            prod_name[2] = searchPhrase;

            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var valid_till = (Opt.Filter[2] as object[])[0] as object[];
            valid_till[2] = date;
        }

        [JsonProperty("opt")]
        public Opt Opt { get; set; }
    }

    public class Opt
    {
        [JsonProperty("filter")]
        public object[] Filter { get; set; } = [
            new object[]
            {
                new object[] { "product_reg_number_2023", "contains", null },
                "or",
                new object[] { "product_name", "contains", null }
            },
            "and",
            new object[]
            {
                new object[] { "res_valid_till", ">=", null },
                "and",
                new object[] { "res_end_date", "=", null }
            }];

        [JsonProperty("requireTotalCount")]
        public bool RequireTotalCount { get; set; } = true;

        [JsonProperty("searchOperation")]
        public string SearchOperation { get; set; } = "contains";

        [JsonProperty("searchValue")]
        public string? SearchValue { get; set; } = null;

        [JsonProperty("skip")]
        public int Skip { get; set; } = 0;
        
        [JsonProperty("sort")]
        public string? Sort { get; set; } = null;

        [JsonProperty("take")]
        public int Take { get; set; } = 20;

        [JsonProperty("userData")]
        public Dictionary<string, object> UserData { get; set; } = [];
    }
}

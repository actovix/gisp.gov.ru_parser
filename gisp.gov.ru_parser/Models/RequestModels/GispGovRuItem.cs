using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace gisp.gov.ru_parser.Models.RequestModels
{
    public class GispGovRuItem
    {
        [JsonProperty("gisp_url")]
        public string GispUrl { get; set; }

        [JsonProperty("product_gisp_url")]
        public string ProductGispUrl { get; set; }

        [JsonProperty("org_name")]
        public string OrgName { get; set; }

        [JsonProperty("org_inn")]
        public string OrgInn { get; set; }

        [JsonProperty("org_ogrn")]
        public string OrgOgrn { get; set; }

        [JsonProperty("product_reg_number_2022")]
        public string ProductRegNumber2022 { get; set; }

        [JsonProperty("product_reg_number_2023")]
        public string ProductRegNumber2023 { get; set; }

        [JsonProperty("ektru_dp")]
        public string EktruDp { get; set; }

        [JsonProperty("res_date")]
        public DateTime? ResDate { get; set; }

        [JsonProperty("res_valid_till")]
        public DateTime? ResValidTill { get; set; }

        [JsonProperty("res_end_date")]
        public DateTime? ResEndDate { get; set; }

        [JsonProperty("product_writeout_url")]
        public string ProductWriteoutUrl { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("product_okpd2")]
        public string ProductOkpd2 { get; set; }

        [JsonProperty("product_tnved")]
        public string ProductTnved { get; set; }

        [JsonProperty("product_spec")]
        public string ProductSpec { get; set; }

        [JsonProperty("product_score_value")]
        public double? ProductScoreValue { get; set; }

        [JsonProperty("product_percentage")]
        public decimal? ProductPercentage { get; set; }

        [JsonProperty("product_score_desc")]
        public string ProductScoreDesc { get; set; }

        [JsonProperty("is_ai_tpp")]
        public bool? IsAiTpp { get; set; }

        [JsonProperty("basedondoc_name")]
        public string BasedondocName { get; set; }

        [JsonProperty("basedondoc_date")]
        public DateTime? BasedondocDate { get; set; }

        [JsonProperty("basedondoc_num")]
        public string BasedondocNum { get; set; }

        [JsonProperty("basedondoc_exp")]
        public DateTime? BasedondocExp { get; set; }

        [JsonProperty("res_mptdep_name")]
        public string ResMptdepName { get; set; }

        [JsonProperty("res_number")]
        public string ResNumber { get; set; }

        [JsonProperty("res_scan_url")]
        public string ResScanUrl { get; set; }
    }

    public class GispGovRuResponse
    {
        [JsonProperty("items")]
        public List<GispGovRuItem> Items { get; set; }

        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }

}

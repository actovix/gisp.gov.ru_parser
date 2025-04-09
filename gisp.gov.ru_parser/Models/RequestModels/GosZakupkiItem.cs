namespace gisp.gov.ru_parser.Models.RequestModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class GosZakupkiItem
    {
        [JsonProperty("result")]
        public List<ResultItem> Result { get; set; }

        [JsonProperty("totalDocuments")]
        public int TotalDocuments { get; set; }

        [JsonProperty("matchedDocuments")]
        public int MatchedDocuments { get; set; }

        [JsonProperty("responseSize")]
        public int ResponseSize { get; set; }
    }

    public class ResultItem
    {
        [JsonProperty("_id")]
        public Id Id { get; set; }

        [JsonProperty("documentype")]
        public string DocumentType { get; set; }

        [JsonProperty("documentname")]
        public string DocumentName { get; set; }

        [JsonProperty("goodsname")]
        public string GoodsName { get; set; }

        [JsonProperty("expertactenddate")]
        public string ExpertActEndDate { get; set; }

        [JsonProperty("goodsokpd2")]
        public string GoodsOkpd2 { get; set; }

        [JsonProperty("tnved")]
        public string Tnved { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("attachmentid")]
        public List<string> AttachmentId { get; set; }

        [JsonProperty("document_date_issue")]
        public string DocumentDateIssue { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("identitycode")]
        public string IdentityCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("statemember")]
        public string StateMember { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("applicationitemstatus")]
        public int ApplicationItemStatus { get; set; }

        [JsonProperty("registrynumber")]
        public string RegistryNumber { get; set; }

        [JsonProperty("authorizedbody")]
        public string AuthorizedBody { get; set; }

        [JsonProperty("publishdate")]
        public string PublishDate { get; set; }

        [JsonProperty("industrialid")]
        public string IndustrialId { get; set; }
    }

    public class Id
    {
        [JsonProperty("$oid")]
        public string Oid { get; set; }
    }

}

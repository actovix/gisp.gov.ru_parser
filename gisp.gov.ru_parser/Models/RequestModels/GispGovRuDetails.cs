using Newtonsoft.Json;

namespace gisp.gov.ru_parser.Models.RequestModels
{
    public class GispGovRuDetails
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("form")]
        public string Form { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("availableCount")]
        public int? AvailableCount { get; set; }

        [JsonProperty("cartCount")]
        public int CartCount { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public decimal? Cost { get; set; }

        [JsonProperty("costNds")]
        public decimal? CostNds { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fillMarketplaceData")]
        public bool FillMarketplaceData { get; set; }

        [JsonProperty("gost")]
        public string Gost { get; set; }

        [JsonProperty("gosts")]
        public List<Gost> GOSTs { get; set; }

        [JsonProperty("id1604")]
        public int Id1604 { get; set; }

        [JsonProperty("companyUrl")]
        public string CompanyUrl { get; set; }

        [JsonProperty("industrialArea")]
        public string IndustrialArea { get; set; }

        [JsonProperty("industrialAreas")]
        public List<IndustrialArea> IndustrialAreas { get; set; }

        [JsonProperty("industryIds")]
        public List<int> IndustryIds { get; set; }

        [JsonProperty("isComparing")]
        public bool IsComparing { get; set; }

        [JsonProperty("isFavourite")]
        public bool IsFavourite { get; set; }

        [JsonProperty("iso")]
        public string Iso { get; set; }

        [JsonProperty("isos")]
        public List<string> Isos { get; set; }

        [JsonProperty("marketplaceCode")]
        public string MarketplaceCode { get; set; }

        [JsonProperty("marketplaceId")]
        public int? MarketplaceId { get; set; }

        [JsonProperty("minCount")]
        public int? MinCount { get; set; }

        [JsonProperty("nameEn")]
        public string NameEn { get; set; }

        [JsonProperty("ndsRate")]
        public int? NdsRate { get; set; }

        [JsonProperty("ntdCode")]
        public string NtdCode { get; set; }

        [JsonProperty("okeiId")]
        public int OkeiId { get; set; }

        [JsonProperty("okpd2")]
        public Okpd2 Okpd2 { get; set; }

        [JsonProperty("ktru")]
        public string Ktru { get; set; }

        [JsonProperty("ktruComment")]
        public string KtruComment { get; set; }

        [JsonProperty("opk")]
        public bool Opk { get; set; }

        [JsonProperty("photoUrl")]
        public string PhotoUrl { get; set; }

        [JsonProperty("photos")]
        public List<string> Photos { get; set; }

        [JsonProperty("regionIds")]
        public List<int> RegionIds { get; set; }

        [JsonProperty("productTypeId")]
        public int ProductTypeId { get; set; }

        [JsonProperty("technologicalDirections")]
        public List<ProductCategory> TechnologicalDirections { get; set; }

        [JsonProperty("thematicCatalogId")]
        public int? ThematicCatalogId { get; set; }

        [JsonProperty("tnved")]
        public List<Tnved> Tnved { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; }

        [JsonProperty("yearFrom")]
        public int? YearFrom { get; set; }

        [JsonProperty("yearTo")]
        public int? YearTo { get; set; }

        [JsonProperty("sampleCharacteristics")]
        public List<SampleCharacteristic> SampleCharacteristics { get; set; }

        [JsonProperty("characteristics")]
        public List<Characteristic> Characteristics { get; set; }
    }

    public class ProductCategory
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gisp_id")]
        public int GispId { get; set; }

        [JsonProperty("deprecated")]
        public bool Deprecated { get; set; }
    }

    public class Company
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("catalogId")]
        public int CatalogId { get; set; }

        [JsonProperty("gispId")]
        public int GispId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("inn")]
        public string Inn { get; set; }

        [JsonProperty("ogrn")]
        public string Ogrn { get; set; }

        [JsonProperty("regionId")]
        public int RegionId { get; set; }
    }

    public class Country
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("alpha2")]
        public string Alpha2 { get; set; }

        [JsonProperty("alpha3")]
        public string Alpha3 { get; set; }

        [JsonProperty("datamosOksmGid")]
        public int DatamosOksmGid { get; set; }

        [JsonProperty("deprecated")]
        public bool Deprecated { get; set; }
    }

    public class Gost
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("deprecated")]
        public bool Deprecated { get; set; }
    }

    public class IndustrialArea
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("gispId")]
        public int GispId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("isDeprecated")]
        public bool IsDeprecated { get; set; }
    }

    public class Okpd2
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("parentId")]
        public int ParentId { get; set; }
    }

    public class Tnved
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("parentId")]
        public int ParentId { get; set; }
    }

    public class SampleCharacteristic
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("okeiId")]
        public int? OkeiId { get; set; }

        [JsonProperty("okpd2Id")]
        public int Okpd2Id { get; set; }

        [JsonProperty("ktruId")]
        public int? KtruId { get; set; }

        [JsonProperty("productCharacteristicTypeId")]
        public int ProductCharacteristicTypeId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isRequired")]
        public bool? IsRequired { get; set; }

        [JsonProperty("concreteValues")]
        public List<string> ConcreteValues { get; set; }

        [JsonProperty("numericIntervalValues")]
        public List<object> NumericIntervalValues { get; set; }

        [JsonProperty("existingValues")]
        public List<string> ExistingValues { get; set; }

        [JsonProperty("boundaryMin")]
        public double? BoundaryMin { get; set; }

        [JsonProperty("boundaryMax")]
        public double? BoundaryMax { get; set; }
    }

    public class Characteristic
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("groupId")]
        public int? GroupId { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("okeiId")]
        public int? OkeiId { get; set; }

        [JsonProperty("productCharacteristicTypeId")]
        public int ProductCharacteristicTypeId { get; set; }

        [JsonProperty("significance")]
        public Significance Significance { get; set; }

        [JsonProperty("exactNumericValues")]
        public List<ExactNumericValue> ExactNumericValues { get; set; }

        [JsonProperty("intervalNumericValues")]
        public List<ProductCharacteristicValue> IntervalNumericValues { get; set; }

        [JsonProperty("textValues")]
        public List<TextValue> TextValues { get; set; }
    }

    public class ProductCharacteristicValue
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("productCharacteristicId")]
        public int ProductCharacteristicId { get; set; }

        [JsonProperty("lowerTolerance")]
        public double? LowerTolerance { get; set; }

        [JsonProperty("relativeTolerance")]
        public bool RelativeTolerance { get; set; }

        [JsonProperty("upperTolerance")]
        public double? UpperTolerance { get; set; }

        [JsonProperty("lowerValue")]
        public double LowerValue { get; set; }

        [JsonProperty("upperValue")]
        public double UpperValue { get; set; }
    }

    public class Significance
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("characteristicId")]
        public int? CharacteristicId { get; set; }

        [JsonProperty("characteristicCode")]
        public string CharacteristicCode { get; set; }

        [JsonProperty("isRequired")]
        public bool IsRequired { get; set; }
    }

    public class ExactNumericValue
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("productCharacteristicId")]
        public int ProductCharacteristicId { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("relativeTolerance")]
        public bool RelativeTolerance { get; set; }

        [JsonProperty("lowerTolerance")]
        public double? LowerTolerance { get; set; }

        [JsonProperty("upperTolerance")]
        public double? UpperTolerance { get; set; }
    }

    public class TextValue
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("productCharacteristicId")]
        public int ProductCharacteristicId { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

}

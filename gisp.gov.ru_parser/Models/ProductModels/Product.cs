namespace gisp.gov.ru_parser.Models.ProductModels;

public class Product
{
    public string Code { get; set; } = "";

    public string Name { get; set; } = "";

    public Decimal Price { get; set; } = 0;

    public string PriceCurrency { get; set; } = "";

    public int QuantityCurrent { get; set; } = 0;

    public int QuantityInStock { get; set; } = 0;

    public string Link { get; set; } = "";
    
    public string CatalogPath { get; set; } = "";
}

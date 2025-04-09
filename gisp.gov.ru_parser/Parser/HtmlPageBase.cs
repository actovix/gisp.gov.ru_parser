using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using gisp.gov.ru_parser.Exceptions;
using gisp.gov.ru_parser.Helpers;
using gisp.gov.ru_parser.Models.ProductModels;

namespace gisp.gov.ru_parser.Parser;

public class HtmlPageBase
{
    private string _urlBase;

    private readonly string _contentSelector;
    private readonly string _productsGroupSelector;
    private readonly string _propertyGroupSelector;

    private readonly string _productNameSelector;
    private readonly string _productLinkSelector;
    private readonly string _productLinkAttribute;
    private readonly string _productPriceSelector;
    private readonly string _productPriceCurrency;

    private readonly string _detailsNameSelector;
    private readonly string _detailsPriceSelector;
    private readonly string _detailsPriceCurrency;
    private readonly string _detailsPropNameSelector;
    private readonly string _detailsPropValueSelector;

    private protected IHtmlDocument _document;

    public HtmlPageBase(
        string urlBase,
        string contSel,
        string prodGrSel,
        string propGrSel,
        string prodNameSel,
        string prodLinkSel,
        string prodLinkAttr,
        string prodPriceSel,
        string prodPrCur,
        string detNameSel,
        string detPriceSel,
        string detPrCur,
        string detPropNameSel,
        string detPropValSel)
    {
        _urlBase = urlBase;
        _contentSelector = contSel;
        _productsGroupSelector = prodGrSel;
        _propertyGroupSelector = propGrSel;

        _productNameSelector = prodNameSel;
        _productLinkSelector = prodLinkSel;
        _productLinkAttribute = prodLinkAttr;
        _productPriceSelector = prodPriceSel;
        _productPriceCurrency = prodPrCur;

        _detailsNameSelector = detNameSel;
        _detailsPriceSelector = detPriceSel;
        _detailsPriceCurrency = detPrCur;
        _detailsPropNameSelector = detPropNameSel;
        _detailsPropValueSelector = detPropValSel;
    }

    public async Task TryParse(string source)
    {
        if (string.IsNullOrEmpty(source))
        {
            throw new HtmlParserException("Html parsing error");
        }
        
        var res = await new HtmlParser().ParseDocumentAsync(source);

        _document = res;
    }

    public async Task<List<ProductDetails>> GetDetails()
    {
        var res = new List<ProductDetails>();

        var cont = _document.QuerySelector(_contentSelector);

        if (cont is null)
        {
            res.Add(new());
            return res;
        }

        res.Add(
            new()
            {
                Name = cont.GetAttribute<string>(_detailsNameSelector) ?? "",
                Price = cont.GetAttribute<decimal>(_detailsPriceSelector),
                PriceCurrency = _detailsPriceCurrency,
                Properties = GetProps(cont),
            }
        );

        return res;
    }

    private protected List<Property> GetProps(IElement cont)
    {
        var props = new List<Property>();

        var propGroup = cont.QuerySelectorAll(_propertyGroupSelector);

        foreach (var item in propGroup)
        {
            props.Add(
                new()
                {
                    Name = item.GetAttribute<string>(_detailsPropNameSelector) ?? "",
                    Value = item.GetAttribute<string>(_detailsPropValueSelector) ?? ""
                }
            );
        }

        props = props.Where(x => x.Name != "" && x.Value != "").ToList();

        return props;
    }

    public async Task<List<Product>> GetProducts()
    {
        var res = new List<Product>();

        var group = _document.QuerySelectorAll(_productsGroupSelector);

        foreach (var item in group)
        {
            res.Add(
                new()
                {
                    Name = item.GetAttribute<string>(_productNameSelector) ?? "",
                    Link = _urlBase + item.GetAttribute<string>(_productLinkSelector, _productLinkAttribute) ?? "",
                    Price = item.GetAttribute<decimal>(_productPriceSelector),
                    PriceCurrency = _productPriceCurrency,
                }
            );
        }

        return res;
    }
}

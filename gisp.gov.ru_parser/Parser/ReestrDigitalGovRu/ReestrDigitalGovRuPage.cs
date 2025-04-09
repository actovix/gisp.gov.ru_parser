namespace gisp.gov.ru_parser.Parser.ReestrDigitalGovRu
{
    public class ReestrDigitalGovRuPage : HtmlPageBase
    {
        public ReestrDigitalGovRuPage() : base(
            urlBase: "https://reestr.digital.gov.ru", 
            contSel: "body", 
            prodGrSel: ".item.collection-item.a-link", 
            prodNameSel: "div:first-child", 
            prodLinkSel: "", 
            prodLinkAttr: "data-href", 
            prodPriceSel: "empty.selector", 
            prodPrCur: "RUB", 
            detNameSel: ".page-title h1", 
            detPriceSel: "empty.selector", 
            detPrCur: "RUB", 
            propGrSel: ".tabs-content div:has(label)", 
            detPropNameSel: "label", 
            detPropValSel: "div")
        {
        }
    }
}

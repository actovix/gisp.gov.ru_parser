using gisp.gov.ru_parser.Models.Configs;
using Microsoft.Extensions.Options;

namespace gisp.gov.ru_parser.Parser.ReestrDigitalGovRu
{
    public class ReestrDigitalGovRuParser(ParserBase parser, IOptions<ReestrDigitalGovRuConfig> options) : ParserLinker<ReestrDigitalGovRuConfig, ReestrDigitalGovRuPage>(parser, options)
    {
    }
}

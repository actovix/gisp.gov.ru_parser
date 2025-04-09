using gisp.gov.ru_parser.Models.ApiModels;
using gisp.gov.ru_parser.Models.Configs;
using gisp.gov.ru_parser.Parser;
using gisp.gov.ru_parser.Parser.ReestrDigitalGovRu;
using Microsoft.AspNetCore.Mvc;

namespace gisp.gov.ru_parser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReestrDigitalGovRuController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly ParserLinker<ReestrDigitalGovRuConfig, ReestrDigitalGovRuPage> _parser;

        public ReestrDigitalGovRuController(
            Serilog.ILogger logger, 
            ParserLinker<ReestrDigitalGovRuConfig, ReestrDigitalGovRuPage> parser)
        {
            _logger = logger;
            _parser = parser;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchProducts([FromBody] SearchRequest searchRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = await _parser.GetProducts(searchRequest, HttpContext.RequestAborted);
            res.App = searchRequest.App;

            return Ok(res);
        }

        [HttpPost("details")]
        public async Task<IActionResult> GetProductDetails([FromBody] DetailsRequest detailsRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = await _parser.GetDetails(detailsRequest, HttpContext.RequestAborted);
            res.App = detailsRequest.App;

            return Ok(res);
        }
    }
}

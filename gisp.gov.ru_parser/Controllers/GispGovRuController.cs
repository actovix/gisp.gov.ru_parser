

using gisp.gov.ru_parser.Models.ApiModels;
using gisp.gov.ru_parser.Parser.Gisp.gov;
using Microsoft.AspNetCore.Mvc;

namespace gisp.gov.ru_parser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GispGovRuController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly GispGovRuParser _gispGovRuParser;

        public GispGovRuController(
            Serilog.ILogger logger,
            GispGovRuParser gispGovRuParser)
        {
            _logger = logger;
            _gispGovRuParser = gispGovRuParser;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchProducts([FromBody] SearchRequest searchRequest)
        {
            var res = await _gispGovRuParser.GetProducts(searchRequest, HttpContext.RequestAborted);
            res.App = searchRequest.App;

            return Ok(res);
        }

        [HttpPost("details")]
        public async Task<IActionResult> GetProductDetails([FromBody] DetailsRequest detailsRequest)
        {
            var res = await _gispGovRuParser.GetDetails(detailsRequest, HttpContext.RequestAborted);
            res.App = detailsRequest.App;

            return Ok(res);
        }
    }
}

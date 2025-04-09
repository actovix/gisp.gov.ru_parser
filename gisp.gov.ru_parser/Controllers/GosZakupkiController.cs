using gisp.gov.ru_parser.Models.ApiModels;
using gisp.gov.ru_parser.Parser.Gisp.gov;
using gisp.gov.ru_parser.Parser.GosZakupki;
using Microsoft.AspNetCore.Mvc;

namespace gisp.gov.ru_parser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GosZakupkiController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly GosZakupkiParser _gosZakupkiParser;

        public GosZakupkiController(
            Serilog.ILogger logger,
            GosZakupkiParser gosZakupkiParser)
        {
            _logger = logger;
            _gosZakupkiParser = gosZakupkiParser;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchProducts([FromBody] SearchRequest searchRequest)
        {
            var res = await _gosZakupkiParser.GetProducts(searchRequest, HttpContext.RequestAborted);
            res.App = searchRequest.App;

            return Ok(res);
        }

        [HttpPost("details")]
        public async Task<IActionResult> GetProductDetails([FromBody] DetailsRequest detailsRequest)
        {
            var res = await _gosZakupkiParser.GetDetails(detailsRequest, HttpContext.RequestAborted);
            res.App = detailsRequest.App;

            return Ok(res);
        }
    }
}

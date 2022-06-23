using Angular_Shop.API.Client;
using Angular_Shop.API.Responses;
using Angular_Shop.Domain.ApiModels;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Angular_Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [ApiVersion("1.0")]
    public class ExchangesController : ControllerBase
    {
        private readonly ILogger<ExchangesController> _logger;
        private readonly CurrencyClient _client;

        public ExchangesController(ILogger<ExchangesController> logger, CurrencyClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet("convert")]
        public async Task<CurrencyResponse> ConvertCurrency([FromQuery] CurrencyApiModel model)
        {
            _logger.LogInformation("Converting currency to another.");

            var result = await _client.ConvertCurrency(model.From, model.To, model.Amount);

            return result;
        }
    }
}

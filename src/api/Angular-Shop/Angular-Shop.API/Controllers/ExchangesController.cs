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
        private readonly IMapper _mapper;

        public ExchangesController(ILogger<ExchangesController> logger, CurrencyClient client, IMapper mapper)
        {
            _logger = logger;
            _client = client;
            _mapper = mapper;
        }

        [HttpGet("convert")]
        public async Task<CurrencyResponse> ConvertCurrency([FromQuery] CurrencyApiModel model)
        {
            _logger.LogInformation("Converting currency to another.");

            var currency = await _client.ConvertCurrency(model.From, model.To, model.Amount);
            var result = _mapper.Map<CurrencyResponse>(currency);

            return result;
        }
    }
}

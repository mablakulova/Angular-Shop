using Angular_Shop.API.Responses;
using Angular_Shop.Domain.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Angular_Shop.API.Client
{
    public class CurrencyClient
    {
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly JsonSerializerOptions _options;
		private readonly ExchangeClientOptions _clientOptions;

		public CurrencyClient(IHttpClientFactory httpClientFactory, 
			IOptions<ExchangeClientOptions> clientOptions)
		{
			_httpClientFactory = httpClientFactory;
			_options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			_clientOptions = clientOptions.Value;
		}
        
		private HttpClient GetHttpClient()
		{
			var httpClient = _httpClientFactory.CreateClient("ExchangeClient");

			httpClient.BaseAddress = new Uri(_clientOptions.BaseUrl);
			return httpClient;
		}

		public async Task<CurrencyResponse> ConvertCurrency(string from, string to, double amount)
		{

			using (var response = await GetHttpClient().GetAsync($"/convert?from={from}&to={to}&amount={amount}"))
			{
				response.EnsureSuccessStatusCode();

				var content = response.Content.ReadAsStringAsync().Result;

				var result = JsonSerializer.Deserialize<CurrencyResponse>(content, _options);

				return result;
			}
		}
	}
}

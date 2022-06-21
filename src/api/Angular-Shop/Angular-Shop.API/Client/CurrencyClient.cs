using Angular_Shop.API.Responses;
using System.Text.Json;

namespace Angular_Shop.API.Client
{
	public class CurrencyClient
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly JsonSerializerOptions _options;

		public CurrencyClient(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
			_options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
		}

		public async Task<CurrencyResponse> ConvertCurrency(string from, string to, double amount)
		{
			var httpClient = _httpClientFactory.CreateClient("ExchangeClient");

			using (var response = await httpClient.GetAsync($"/convert?from={from}&to={to}&amount={amount}"))
			{
				response.EnsureSuccessStatusCode();

				var content = response.Content.ReadAsStringAsync().Result;

				var result = JsonSerializer.Deserialize<CurrencyResponse>(content, _options);

				return result;
			}
		}
	}
}

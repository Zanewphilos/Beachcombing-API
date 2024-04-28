using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Beachcombing_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapsProxyController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _azureMapsKey;

        public MapsProxyController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _azureMapsKey = configuration["AzureMaps:SubscriptionKey"];
        }

        [HttpGet]
        [Route("Geocode")]
        public async Task<IActionResult> Geocode([FromQuery] string query)
        {
            var client = _httpClientFactory.CreateClient();

            string baseUrl = "https://atlas.microsoft.com/search/address/json";
            string url = $"{baseUrl}?api-version=1.0&subscription-key={_azureMapsKey}&query={query}";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }

            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        [HttpGet]
        [Route("GeocodeByCoordinates")]
        public async Task<IActionResult> GeocodeByCoordinates([FromQuery] double latitude, [FromQuery] double longitude)
        {
            var client = _httpClientFactory.CreateClient();

            string baseUrl = "https://atlas.microsoft.com/search/address/reverse/json";
            string url = $"{baseUrl}?api-version=1.0&subscription-key={_azureMapsKey}&query={latitude},{longitude}";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }

            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        

    }


}

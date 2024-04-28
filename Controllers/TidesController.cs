using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TidesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _worldTidesApiKey;

        public TidesController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _worldTidesApiKey = configuration["ApiKeys:WorldTides"];
        }

        [HttpGet]
        public async Task<IActionResult> GetTides([FromQuery] double latitude, [FromQuery] double longitude)
        {
            var client = _httpClientFactory.CreateClient();
            // 指定想要获取极值和接下来三天的数据
            string url = $"https://www.worldtides.info/api/v2?extremes&lat={latitude}&lon={longitude}&days=3&key={_worldTidesApiKey}";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            Console.WriteLine(response.Content.ReadAsStringAsync());
            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
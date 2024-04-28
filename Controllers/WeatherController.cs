using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;


    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _openWeatherApiKey;

        public WeatherController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _openWeatherApiKey = configuration["ApiKeys:OpenWeather"];
        }

    [HttpGet]
    public async Task<IActionResult> GetWeather([FromQuery] double latitude, [FromQuery] double longitude)
    {
        var client = _httpClientFactory.CreateClient();
        // 添加exclude参数以排除不需要的数据部分，比如minutely
        // 添加units参数来获取以特定单位（比如metric或imperial）表示的数据
        string url = $"https://api.openweathermap.org/data/3.0/onecall?lat={latitude}&lon={longitude}&exclude=minutely&units=metric&appid={_openWeatherApiKey}";

        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }

        return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
    }
}

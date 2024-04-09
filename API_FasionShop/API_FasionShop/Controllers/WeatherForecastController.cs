using API_FashionShop.Services;
using MailKit;
using Microsoft.AspNetCore.Mvc;

namespace API_FasionShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        ISendMailService service;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ISendMailService mailService)
        {
            _logger = logger;
            service = mailService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<bool> SendEMail(string email, string name)
        {
            string content = "<h1>Thông báp sắp đến hạn trả sách</h1>" +
                "<p>Thân gửi " + name + "" + "Bạn có đang mượn sách của thư viện BKE" +
                " và sắp tới hạn trả sách ngày" + DateTime.Today + "." +
                "Mong bạn sẽ trả sách đúng hạn!</p>";
            await service.SendEmailAsync(email, "Thông báp sắp đến hạn trả sách", content);
            return true;
        }
    }
}
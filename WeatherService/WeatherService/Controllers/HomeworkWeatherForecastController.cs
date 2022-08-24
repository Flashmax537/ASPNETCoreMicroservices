using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherService.Models;

namespace WeatherService.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class HomeworkWeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastHolder _holder;

        public HomeworkWeatherForecastController(WeatherForecastHolder holder)
        {
            _holder = holder;
        }

        //Возможность сохранить температуру в указанное время
        [HttpPost("add")]
        public IActionResult Add([FromQuery] DateTime date, [FromQuery] int temperatureC)
        {
            _holder.Add(date, temperatureC);
            return Ok();
        }

        //Возможность отредактировать показатель температуры в указанное время
        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime date, [FromQuery] int temperatureC)
        {
            return Ok(_holder.Update(date, temperatureC));
        }

        //Возможность прочитать список показателей температуры за указанный промежуток времени
        [HttpGet("get")]
        public IEnumerable<WeatherForecast> Get([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)
        {
            return _holder.Get(dateFrom, dateTo);
        }

        //Возможность удалить показатель температуры в указанный промежуток времени
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime dateFrom)
        {
            _holder.Delete(dateFrom);
            return Ok();
        }
    }
}

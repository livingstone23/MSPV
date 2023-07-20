using Microsoft.AspNetCore.Mvc;
using System;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.ComponentModel.DataAnnotations;

namespace PVM.Service.OCR.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet("GetWeatherForecast", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }



        [HttpGet("GetSuma", Name = "GetSuma")]
        public ActionResult GetSuma([FromQuery] ValueDTO values)
        {

            string pathpy = @"C:\git\mspv\PVM.Service.OCR\pythonTest\dummy.py";
            ScriptRuntime py = Python.CreateRuntime();
            dynamic pyProgram = py.UseFile(pathpy);

            var result = pyProgram.suma(values.ValueA, values.ValueB);
            return Ok(result);

        }


    }

    public class ValueDTO
    {
       
        [Required(ErrorMessage = "Value is required")]
        public int ValueA { get; set; }

        [Required(ErrorMessage = "Value is required")]
        public int ValueB { get; set; }
    }
}
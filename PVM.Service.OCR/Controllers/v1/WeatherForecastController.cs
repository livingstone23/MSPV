using Microsoft.AspNetCore.Mvc;
using System;
using Python.Runtime;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;
using PVM.Service.OCR.Services.EnablePython;

namespace PVM.Service.OCR.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEnablePython _enablePython;

        public WeatherForecastController(IEnablePython enablePython, ILogger<WeatherForecastController> logger)
        {
            _enablePython = enablePython;
            _logger = logger;

        }


        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        




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
            // Enable Python service
            _enablePython.InitializeService();
            //Sumatorio
            using (Py.GIL()) // Acquire the Python GIL (Global Interpreter Lock)
            { 
                dynamic os = Py.Import("os");
                dynamic sys = Py.Import("sys");
                dynamic pytes = Py.Import("pytesseract");
                dynamic np = Py.Import("numpy");

                // Load the Python script
                string filePath = "C:\\Otros\\mspv2\\PVM.Service.OCR\\pythonTest\\dummy.py";
                sys.path.append(os.path.dirname(filePath));
                dynamic dummy = Py.Import(Path.GetFileNameWithoutExtension(filePath));

                filePath = "C:\\Otros\\mspv2\\PVM.Service.OCR\\Python\\main.py";
                sys.path.append(os.path.dirname(filePath));
                dynamic main = Py.Import(Path.GetFileNameWithoutExtension(filePath));

                main.InvokeMethod("main");

                // Convert C# values to Python objects
                PyObject[] pyParams = { values.ValueA.ToPython(), values.ValueB.ToPython() };

                // Call the Python function and get the result
                int result = dummy.InvokeMethod("suma", pyParams);
                
                return Ok(result);
            }
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
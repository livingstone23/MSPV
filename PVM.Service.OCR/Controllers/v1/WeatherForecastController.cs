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


        // El método PythonOCRInference, llama a la función extract_pdf y lee el documento que se le pasa como ruta, ya sea un pdf o una ruta que los contiene
        [HttpGet("PythonOCRInference", Name = "PythonOCRInference")]
        public ActionResult PythonOCRInference()
        {
            // Enable Python service
            _enablePython.InitializeService();

            // Inferir OCR
            using (Py.GIL()) // Acquire the Python GIL (Global Interpreter Lock)
            {
                dynamic os = Py.Import("os");
                dynamic sys = Py.Import("sys");

                string filePath = @"C:\\Otros\\mspv2\\PVM.Service.OCR\\Python\\main.py";
                sys.path.append(os.path.dirname(filePath));
                dynamic main = Py.Import(Path.GetFileNameWithoutExtension(filePath));
                
                string images_path = @"C:\Otros\OCR py\DATASET clasificador\Upload tests\EFAC_P9793_176726_20191121_110407067.pdf";

                string plantilla = System.IO.File.ReadAllText(@"..\PVM.Service.OCR\Python\temp\plantilla_test_compressed.json");

                main.extract_pdf("1", images_path, plantilla);

                return Ok();
            }
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

        // El método GetSuma, llama a la función main y lee los documentos y saca por pantalla la ocr antigua
        // te pide una selección que en este caso serían las líneas de la factura
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

                //@"C:\\Otros\\OCR py\\DATASET clasificador\\Imagenes de Upload test"

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
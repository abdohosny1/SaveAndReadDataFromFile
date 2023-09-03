using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace SaveDataInFile.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [Route("SaveData")]
        public IActionResult SaveDataInFile()
        {
            var mokData = MokData.FakeData();

            try
            {
                // Define the file path where you want to save the data
                string filePath = "data.txt"; // Replace with your desired file path

                // Serialize the data to a JSON string
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(mokData);

                // Write the JSON string to the file
                System.IO.File.WriteAllText(filePath, jsonString);

                return Ok("Data saved successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error saving data: {ex.Message}");
            }
        }

        [HttpGet("read")]
        public IActionResult ReadDataFromFile()
        {
            try
            {
                // Define the file path from which you want to read the data
                string filePath = "data.txt"; // Replace with your file path

                if (System.IO.File.Exists(filePath))
                {
                    // Read the content of the file
                    string jsonString = System.IO.File.ReadAllText(filePath);

                    // Deserialize the JSON string to a list of strings
                    List<Item> data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Item>>(jsonString);

                    // You now have the data from the file in the 'data' variable
                    return Ok(data);
                }
                else
                {
                    return NotFound("File not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error reading data: {ex.Message}");
            }
        }
    }
}
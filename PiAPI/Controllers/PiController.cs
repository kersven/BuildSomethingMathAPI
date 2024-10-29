using Microsoft.AspNetCore.Mvc;

namespace PiAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PiController : Controller
    {
        public PiController() 
        { 
        }

        //Method to return Pi with the specified number of digits after the decimal point
        [HttpGet("pi/{number}")]
        public IActionResult GetPi(int number)
        {
            if (number < 0 || number > 50) // Limit to 50 decimal places due to double precision
            {
                return BadRequest("Please specify a number between 0 and 15 for decimal places.");
            }

            double piValue = Math.PI;
            string formattedPi = piValue.ToString($"F{number}"); // Format Pi to the specified number of decimal places

            return Ok(formattedPi);
        }
    }
}

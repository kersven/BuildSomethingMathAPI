using Microsoft.AspNetCore.Mvc;

namespace FibonacciAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FibonacciController : Controller
    {
        public FibonacciController() 
        { 
        }

        //Method to calculate Fibonacci sequence up to a given number
        [HttpGet("fibonacciSeq/{number}")]
        public IActionResult Fibonacci(int number)
        {
            if (number < 0)
                return BadRequest("Number must be a non-negative integer.");

            var fibonacciList = new List<long> { 0, 1 };

            for (int i = 2; i <= number; i++)
            {
                fibonacciList.Add(fibonacciList[i - 1] + fibonacciList[i - 2]);
            }

            return Ok(fibonacciList.Take(number + 1));
        }
    }
}

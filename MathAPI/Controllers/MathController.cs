using Microsoft.AspNetCore.Mvc;

namespace MathAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MathController : Controller
    {
        public MathController()
        {

        }

        //Method to calculate factorial of a number
        [HttpGet("factorial/{number}")]
        public IActionResult Factorial(int number)
        {
            if (number < 0)
                return BadRequest("Number must be a non-negative integer.");

            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return Ok(result);
        }

        //Method to calculate Prime factorization of a number
        [HttpGet("PrimeFactorization/{number}")]
        public IActionResult PrimeFactorization(int number)
        {
            List<int> factors = new List<int>();

            while (number % 2 == 0)
            {
                factors.Add(2);
                number /= 2;
            }

            for (int divisor = 3; divisor * divisor <= number; divisor += 2)
            {
                while (number % divisor == 0)
                {
                    factors.Add(divisor);
                    number /= divisor;
                }
            }

            if (number > 2)
            {
                factors.Add(number);
            }

            return Ok(factors.Take(number + 1));
        }

        //Method to calculate the list of divisors of a number
        [HttpGet("Divisors/{number}")]
        public IActionResult Divisors(int number)
        {
            List<int> divisors = new List<int>();

            //Loop through numbers from 1 to sqrt(n)
            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                //If i divides n evenly, it is a divisor
                if (number % i == 0)
                {
                    divisors.Add(i);

                    //If the quotient is not the same as i, add it as well
                    if (i != number / i)
                    {
                        divisors.Add(number / i);
                    }
                }
            }

            //Sort the divisors list (optional, to make it ascending)
            divisors.Sort();

            return Ok(divisors.Take(number + 1));
        }

    }


}

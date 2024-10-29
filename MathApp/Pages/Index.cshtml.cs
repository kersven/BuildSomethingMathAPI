using MathApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MathApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MathAPIService _apiService;

        public IndexModel(MathAPIService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public int Number { get; set; }

        public string FactorialResult { get; set; }
        public string PrimeFactorizationResult { get; set; }
        public string DivisorsResult { get; set; }
        public string FibonacciResult { get; set; }
        public string PIResult { get; set; }

        public void OnGet()
        {
            // Initial page load
        }

        public async Task OnPostAsync()
        {
            // Call the API and get the factorial
            FactorialResult = await _apiService.GetFactorialAsync(Number);
            PrimeFactorizationResult = await _apiService.GetPrimeFactorizationAsync(Number);
            DivisorsResult = await _apiService.GetDivisorsAsync(Number);
            FibonacciResult = await _apiService.GetFibonacciSeqAsync(Number);
            PIResult = await _apiService.GetPIAsync(Number);

        }
    }
}
namespace MathApp.Services
{
    public class MathAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _dbContext;

        public MathAPIService(HttpClient httpClient, AppDbContext dbContext)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
        }

        private async Task LogRequestAsync(string endpoint, string requestData)
        {
            var log = new RequestLog
            {
                Endpoint = endpoint,
                RequestData = requestData,
                Timestamp = DateTime.UtcNow
            };

            _dbContext.RequestLogs.Add(log);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> GetFactorialAsync(int number)
        {
            var endpoint = $"http://mathapi/Math/factorial/{number}";
            var response = await _httpClient.GetAsync(endpoint);
            var responseData = await response.Content.ReadAsStringAsync();

            await LogRequestAsync(endpoint, responseData);

            return responseData;
        }

        public async Task<string> GetPrimeFactorizationAsync(int number)
        {
            var endpoint = $"http://mathapi/Math/PrimeFactorization/{number}";
            var response = await _httpClient.GetAsync(endpoint);
            var responseData = await response.Content.ReadAsStringAsync();

            await LogRequestAsync(endpoint, responseData);

            return responseData;
        }

        public async Task<string> GetDivisorsAsync(int number)
        {
            var endpoint = $"http://mathapi/Math/Divisors/{number}";
            var response = await _httpClient.GetAsync(endpoint);
            var responseData = await response.Content.ReadAsStringAsync();

            await LogRequestAsync(endpoint, responseData);

            return responseData;
        }

        public async Task<string> GetFibonacciSeqAsync(int number)
        {
            var endpoint = $"http://fibonacciapi/Fibonacci/fibonacciSeq/{number}";
            var response = await _httpClient.GetAsync(endpoint);
            var responseData = await response.Content.ReadAsStringAsync();

            await LogRequestAsync(endpoint, responseData);

            return responseData;
        }

        public async Task<string> GetPIAsync(int number)
        {
            var endpoint = $"http://piapi/Pi/pi/{number}";
            var response = await _httpClient.GetAsync(endpoint);
            var responseData = await response.Content.ReadAsStringAsync();

            await LogRequestAsync(endpoint, responseData);

            return responseData;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using XenoByte.Models;
using XenoByte.Models.API;
using XenoByte.Models.API.BitCoin;
using XenoByte.Models.API.Ethereum;

namespace XenoByte.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AptGroupThreatIntelligence(string value)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["APIsConfiguration:baseUrl"]}/public/apt?group={value}");
                request.Headers.Add("Accept", "application/json");
                var apiKey = Environment.GetEnvironmentVariable("XApiKey") ?? _configuration["ApiKeys:XApiKey"];
                request.Headers.Add("X-API-Key", apiKey);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<AptGroupThreatIntelligenceModel>(responseContent);

                return View(result);
            }
            catch
            {
                return View("APIError");
            }
        }

        [HttpGet]
        public async Task<IActionResult> TraceCryptocurrencyAddressorTransaction(string value)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["APIsConfiguration:baseUrl"]}/public/crypto_trace?input_string={value}");
                request.Headers.Add("Accept", "application/json");
                var apiKey = Environment.GetEnvironmentVariable("XApiKey") ?? _configuration["ApiKeys:XApiKey"];
                request.Headers.Add("X-API-Key", apiKey);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<TraceCryptocurrencyAddressorTransactionModel>(responseContent);

                return View(result);
            }
            catch
            {
                return View("APIError");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CheckFileHashReputation(string value)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Set timeout to 3 minutes
                    client.Timeout = TimeSpan.FromMinutes(3);

                    var request = new HttpRequestMessage(
                        HttpMethod.Get,
                        $"{_configuration["APIsConfiguration:baseUrl"]}/public/hash/reputation?hash_value={value}"
                    );

                    request.Headers.Add("Accept", "application/json");

                    var apiKey = Environment.GetEnvironmentVariable("XApiKey") ?? _configuration["ApiKeys:XApiKey"];
                    request.Headers.Add("X-API-Key", apiKey);

                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CheckFileHashReputationModel>(responseContent);

                    return View(result);
                }
            }
            catch
            {
                return View("APIError");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PerformBitcoinTransactionHashAnalysis(string value)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["APIsConfiguration:baseUrl"]}/bitcoin/transaction-analysis?tx_hash={value}");
                request.Headers.Add("Accept", "application/json");
                var apiKey = Environment.GetEnvironmentVariable("XApiKey") ?? _configuration["ApiKeys:XApiKey"];
                request.Headers.Add("X-API-Key", apiKey);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<PerformBitcoinTransactionHashAnalysisModel>(responseContent);

                return View(result);
            }
            catch
            {
                return View("APIError");
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PerformBitcoinWalletForensicAnalysis(string value)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["APIsConfiguration:baseUrl"]}/bitcoin/wallet-forensic?wallet_address={value}&max_depth=2");
                request.Headers.Add("Accept", "application/json");
                var apiKey = Environment.GetEnvironmentVariable("XApiKey") ?? _configuration["ApiKeys:XApiKey"];
                request.Headers.Add("X-API-Key", apiKey);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<PerformBitcoinWalletForensicAnalysisModel>(responseContent);

                return View(result);
            }
            catch
            {
                return View("APIError");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CheckBitcoinWalletReputation(string value)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["APIsConfiguration:baseUrl"]}/bitcoin/wallet-reputation?wallet_address={value}");
                request.Headers.Add("Accept", "application/json");
                var apiKey = Environment.GetEnvironmentVariable("XApiKey") ?? _configuration["ApiKeys:XApiKey"];
                request.Headers.Add("X-API-Key", apiKey);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<CheckBitcoinWalletReputationModel>(responseContent);

                return View(result);
            }
            catch
            {
                return View("APIError");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PerformEthereumTransactionHashAnalysis(string value)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["APIsConfiguration:baseUrl"]}/ethereum/transaction-analysis?tx_hash={value}");
                request.Headers.Add("Accept", "application/json");
                var apiKey = Environment.GetEnvironmentVariable("XApiKey") ?? _configuration["ApiKeys:XApiKey"];
                request.Headers.Add("X-API-Key", apiKey);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<PerformEthereumTransactionHashAnalysisModel>(responseContent);

                return View(result);
            }
            catch
            {
                return View("APIError");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PerformEthereumWalletForensicAnalysis(string value)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["APIsConfiguration:baseUrl"]}/ethereum/wallet-forensic?wallet_address={value}&max_depth=2");
                request.Headers.Add("Accept", "application/json");
                var apiKey = Environment.GetEnvironmentVariable("XApiKey") ?? _configuration["ApiKeys:XApiKey"];
                request.Headers.Add("X-API-Key", apiKey);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<PerformEthereumWalletForensicAnalysisModel>(responseContent);

                return View(result);
            }
            catch
            {
                return View("APIError");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CheckEthereumWalletReputation(string value)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["APIsConfiguration:baseUrl"]}/ethereum/wallet-reputation?wallet_address={value}");
                request.Headers.Add("Accept", "application/json");
                var apiKey = Environment.GetEnvironmentVariable("XApiKey") ?? _configuration["ApiKeys:XApiKey"];
                request.Headers.Add("X-API-Key", apiKey);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<CheckEthereumWalletReputationModel>(responseContent);

                return View(result);
            }
            catch
            {
                return View("APIError");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> UploadAndScanFileForReputation(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return View("APIError");
            }

            // Validate file size (10MB limit)
            const long maxFileSize = 10 * 1024 * 1024; // 10MB
            if (file.Length > maxFileSize)
            {
                return View("APIError");
            }

            try
            {
                using (var client = new HttpClient())
                {
                    // Set timeout to 5 minutes for file upload
                    client.Timeout = TimeSpan.FromMinutes(5);

                    // Create multipart form data
                    using (var content = new MultipartFormDataContent())
                    {
                        // Add file content
                        using (var streamContent = new StreamContent(file.OpenReadStream()))
                        {
                            streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType ?? "application/octet-stream");
                            content.Add(streamContent, "file", file.FileName);

                            var request = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["APIsConfiguration:baseUrl"]}/public/file/scan")
                            {
                                Content = content
                            };

                            request.Headers.Add("Accept", "application/json");
                            var apiKey = Environment.GetEnvironmentVariable("XApiKey") ?? _configuration["ApiKeys:XApiKey"];
                            request.Headers.Add("X-API-Key", apiKey);

                            var response = await client.SendAsync(request);
                            response.EnsureSuccessStatusCode();

                            var responseContent = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<UploadFileScanModel>(responseContent);

                            return View(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading and scanning file: {FileName}", file.FileName);
                return View("APIError");
            }
        }
    }
}

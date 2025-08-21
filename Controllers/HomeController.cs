using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using XenoByte.Models;
using XenoByte.Models.API;

namespace XenoByte.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://127.0.0.1:8000/public/apt?group={value}");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-API-Key", "b23f825b20c5c1c7470c8943115876ebcddaa132f854f759863200aba04dcddc");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AptGroupThreatIntelligenceModel>(responseContent);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> TraceCryptocurrencyAddressorTransaction(string value)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://127.0.0.1:8000/public/crypto_trace?input_string={value}");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-API-Key", "b23f825b20c5c1c7470c8943115876ebcddaa132f854f759863200aba04dcddc");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TraceCryptocurrencyAddressorTransactionModel>(responseContent);

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       

    }


}

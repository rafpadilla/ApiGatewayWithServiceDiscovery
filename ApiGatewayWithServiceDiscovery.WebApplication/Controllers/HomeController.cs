using Consul;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGatewayWithServiceDiscovery.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConsulClient _consulClient;

        public HomeController(ILogger<HomeController> logger, IConsulClient consulClient)
        {
            _logger = logger;
            _consulClient = consulClient;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _consulClient.Agent.Services();
            var hostname = Dns.GetHostName();
            var serviceId = services.Response.FirstOrDefault(a => a.Value.Service.Equals("WebApp") && a.Value.Address.Equals(hostname));

            return View(model: serviceId.Key ?? "0");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
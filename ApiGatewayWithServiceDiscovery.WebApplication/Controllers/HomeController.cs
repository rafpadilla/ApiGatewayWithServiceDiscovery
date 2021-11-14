using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGatewayWithServiceDiscovery.WebApplication.Controllers
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
            var hostname = Dns.GetHostName();

            return View(model: hostname);
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
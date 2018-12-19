using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResponseCacheProject.Models;
using Microsoft.Extensions.Logging;

namespace ResponseCacheProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 360)]
        public IActionResult Index1()
        {
            var request = HttpContext.Request;
            _logger.LogDebug($"URL: {request.Host}{request.Path}{request.QueryString}");
            return View(model: DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        [ResponseCache(CacheProfileName  = "Default")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

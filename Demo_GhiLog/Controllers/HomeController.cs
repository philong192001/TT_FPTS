using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Demo_GhiLog.Models;
using Serilog;
using System.IO;

namespace Demo_GhiLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string path = "E://FPTS//3_Tier//Demo_GhiLog//Logging//demo_log.txt";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!Directory.Exists(path))
            {
                Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.File(path, rollingInterval: RollingInterval.Day)
              .CreateLogger();
            }
            else
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File(path, rollingInterval: RollingInterval.Day)
                    .CreateLogger();
            }
           

            Log.Information("Hello, world!, path la : "+ path+" ");

            _logger.LogInformation("The main page has been accessed");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("The privacy page has been accessed");
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

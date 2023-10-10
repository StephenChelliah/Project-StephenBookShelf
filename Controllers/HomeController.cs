using Microsoft.AspNetCore.Mvc;
using StephenBookShelf.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using StephenBookShelf.DATADB;
using System.Net;
using System;

namespace StephenBookShelf.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
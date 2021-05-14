using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentProject.Models;

namespace StudentProject.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public SchoolController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Schools Representatives")]
        public IActionResult SchoolsPage()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Candidates")]
        public IActionResult CandidatePage()
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

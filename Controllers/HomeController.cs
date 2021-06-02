using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SQLitePCL;
using StudentProject.Data;
using StudentProject.Models;
using StudentProject.Models.SeedRoles;
using StudentProject.ViewModels;

namespace StudentProject.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<SchoolsApplicationUser> userManager;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger,
             UserManager<SchoolsApplicationUser> userManager,
             ApplicationDbContext context)
        {
            _logger = logger;
            this.userManager = userManager;
            this.context = context;
        }

        [HttpGet]
        public  IActionResult Index()
        {
            var spellers=  this.context.SpellersTabs.ToList();
            var spellerimages = this.context.SpellersImgs.ToList();

            ListSpellersViewModel model = new ListSpellersViewModel()
            {
                Spellers = spellers,
                SpellersImgs = spellerimages
            };
            foreach(var item in spellers)
            {
                _logger.LogInformation(item.FullName);
            }
            return View(model);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Schools()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Parents()
        {
            return View();
        }

        public IActionResult Sponsors()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Faq()
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

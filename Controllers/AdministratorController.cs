using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StudentProject.Data;
using StudentProject.Models;
using StudentProject.ViewModels;

namespace StudentProject.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly ILogger<AdministratorController> _logger;
        private readonly UserManager<SchoolsApplicationUser> _userManager;
        private readonly SignInManager<SchoolsApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext context;

        public AdministratorController(ILogger<AdministratorController> logger,
            UserManager<SchoolsApplicationUser> userManager,
            SignInManager<SchoolsApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this.context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ListRoles()
        {
            var model = _roleManager.Roles.ToList();
            return View(model);
        }
        [HttpGet]

        //[Authorize(Roles = "Admin")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = createRoleViewModel.RoleName
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    _logger.LogInformation($"New Role {createRoleViewModel.RoleName} has just been aded");
                    return RedirectToAction(nameof(ListRoles));
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        _logger.LogError(item.Description);
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(createRoleViewModel);
        }

        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //public async Task<ActionResult> ListAllStudent()
        //{
        //    IList<ApplicationUser> model = await _userManager.GetUsersInRoleAsync("Student");
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult FilterStudent([FromBody] FilterStudentViewModel filtermodel)
        //{
        //    var user = _userManager.Users.FirstOrDefault(x => x.FirstName == filtermodel.FirstName && x.LastName == filtermodel.LastName);
        //    if (user != null)
        //    {
        //        return Ok(user);
        //    }

        //    return BadRequest("User with the FirstName " + filtermodel.FirstName + " and LastName "
        //        + filtermodel.LastName + " was not found, please check your inputs and try again");

        //}
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentProject.Models;
using StudentProject.ViewModels;

namespace StudentProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUsed(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"the {email} is already in use please choose an another email ");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterStudent()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterStudent(RegisterStudentModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Age = registerViewModel.Age,
                    DateOfBirth = registerViewModel.DateOfBirth,
                    Genders = registerViewModel.Gender,
                    Address = registerViewModel.Address,
                    Class = registerViewModel.Class,
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (!await _roleManager.RoleExistsAsync("Student"))
                    await _roleManager.CreateAsync(new IdentityRole("Student"));

                if (await _roleManager.RoleExistsAsync("Student"))
                {
                    await _userManager.AddToRoleAsync(user, "Student");
                }

                if (result.Succeeded)
                {
                    //ApplicationUser applicationUser = new ApplicationUser()
                    //{
                    //    FirstName = User.Identity.Name
                    //};
                    if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administrator");
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogTrace("Account/Controller");
                        _logger.LogError(error.Description);
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(registerViewModel);
        }

        [HttpGet]
        //[Authorize(Roles ="SuperAdmin")]
        public IActionResult RegisterAdmin()
        {

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,  
                    Genders = registerViewModel.Gender,
                    DateOfBirth = registerViewModel.DateOfBirth,
                    Address = registerViewModel.Address,
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                };

             
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (!await _roleManager.RoleExistsAsync("Admin"))
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));

                if (await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }

                if (result.Succeeded)
                {
                   
                    if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administrator");
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogTrace("Account/Controller");
                        _logger.LogError(error.Description);
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(registerViewModel);
        }
     
        [HttpGet]
        [AllowAnonymous]
        public  IActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.UserName);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.IsPersistent, false);
                    if (result.Succeeded)
                    {
                        if ( returnUrl !=null && Url.IsLocalUrl(returnUrl))
                        {
                            _logger.LogInformation("User is  Logged in");
                            return RedirectToAction(returnUrl);
                        }
                        else
                        {
                            _logger.LogInformation("User is  Logged in");
                            return RedirectToAction("Index", "Home");
                        }
                    }

                    //_logger.LogTrace(result.Exception.StackTrace);
                    //_logger.LogError(result.Exception.Message);
                    ModelState.AddModelError("", "Invalid Input" /*result.Exception.Message*/);

                }

            }
            return View(loginViewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User is Logged out");

            return RedirectToAction("Index", "Home");
        }
    }
}
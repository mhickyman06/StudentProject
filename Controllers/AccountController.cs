using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using StudentProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using SQLitePCL;
using StudentProject.Data;
using StudentProject.Models;
using StudentProject.Models.SeedRoles;
using StudentProject.Repositories;
using StudentProject.ViewModels;
using System.Reflection.Metadata;
using System.Net.Http;
using System.Net;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace StudentProject.Controllers
{
    public class FilterLocalGovt
    {
        public int enumValue { get; set; }
    }

   

    [Route("api/[controller]")]

    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<SchoolsApplicationUser> _userManager;
        private readonly SignInManager<SchoolsApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IFileManagerService _fileservice;
        private readonly IMailService emailsender;
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext _context;

        public AccountController(ILogger<AccountController> logger,
            UserManager<SchoolsApplicationUser> userManager,
            SignInManager<SchoolsApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context,
            IFileManagerService fileservice,
            IMailService _emailsender,
            IConfiguration configuration
        )
        {
            this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._fileservice = fileservice;
            emailsender = _emailsender;
            this.configuration = configuration;
            this._context = context;
        }


        [HttpGet]
        [Route("RegisterSchool")]
        [AllowAnonymous]
        public IActionResult RegisterSchool()
        {
            return View();
        }

        [HttpPost]
        [Route("RegisterSchool")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterSchool(RegisterSchoolViewModel registerViewModel)
        {
         
            var registeredWithinLocalGovt = _context.localGovtSchools.Select(x =>
               x.LocalGovernmentName == registerViewModel.SchoolLocalGovt)
             .Count();
            RegisterSchoolViewModel rgs1 = new RegisterSchoolViewModel();

            var candidateslogin = _userManager.FindByEmailAsync(registerViewModel.Email);


            if (registeredWithinLocalGovt >= 20)
            {
                var message = "The Registration For Schools Under " + registerViewModel.SchoolLocalGovt + " is Closed";
                return RedirectToAction(nameof(CantRegister), message);
            }

            if (ModelState.IsValid)
            {

                var enumdisplaystatus = (States)registerViewModel.SchoolState;
                string enumname = enumdisplaystatus.ToString();


                var schoolTab = new SchoolTab()
                {
                    SchoolName = registerViewModel.SchoolName,
                    SchoolAddress = registerViewModel.SchoolAddress,
                    SchoolLocalGovt = registerViewModel.SchoolLocalGovt,
                    SchoolState = enumname,
                    RelationShip = registerViewModel.RelationShip
                };
               

              

                var schoolapplicationuser = new SchoolsApplicationUser()
                {
                    FullName = registerViewModel.SchoolName,
                    AccountRole = ConstantRoles.School,
                    SchoolTab = schoolTab,
                    SchoolTabId = schoolTab.Id,
                    DateCreated = DateTime.Now.ToString(),
                    CreatedBy = registerViewModel.CreatedBy,
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Email,
                    PhoneNumber = registerViewModel.SchoolPhoneno,

                };
                var SchoollocalGovt = new LocalGovtSchool()
                {
                    LocalGovernmentName = registerViewModel.SchoolLocalGovt,
                    SchoolName = registerViewModel.SchoolName,
                };

                _context.localGovtSchools.Add(SchoollocalGovt);
                await _context.SaveChangesAsync();

                var result1 = await _userManager.CreateAsync(schoolapplicationuser, registerViewModel.ConfirmSchoolPassword);


                if (!await _roleManager.RoleExistsAsync(ConstantRoles.School))
                    await _roleManager.CreateAsync(new IdentityRole { Name = ConstantRoles.School });

                if (await _roleManager.RoleExistsAsync(ConstantRoles.School))
                {
                    await _userManager.AddToRoleAsync(schoolapplicationuser, ConstantRoles.School);
                }


                if (result1.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(schoolapplicationuser);
                    var confirmationLink = Url.Action(nameof(ConfirmEmail),
                        "Account", new { token, email = schoolapplicationuser.Email }, Request.Scheme);

                    var mailRequest = new MailRequest
                    {
                        Body = confirmationLink,
                        Subject = "Confirmation Link",
                        ToEmail = schoolapplicationuser.Email
                    };

                    await emailsender.SendEmailAsync(mailRequest);

                    TempData.Put("Token", token);
                    TempData.Put("UserApplicationEmail", schoolapplicationuser.Email);
                    TempData.Put("Id", schoolapplicationuser.Id);
                    return RedirectToAction(nameof(SuccessRegistration));
                }
                else
                {
                    foreach (var error in result1.Errors)
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
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {

            var SpellersToken = TempData.Get<string>("SpellersToken");
            var Token = TempData.Get<string>("Token");
            var UserApplicationEmail = TempData.Get<string>("UserApplicationEmail");
            var result = new IdentityResult();
            var user = new SchoolsApplicationUser();
            //if (spellersEmail != null)
            //{
            //    spellersuser = await _userManager.FindByEmailAsync(spellersEmail);
            //    result = await _spellerlsusermanager.ConfirmEmailAsync(spellersuser, SpellersToken);
            //}

            if (UserApplicationEmail != null)
            {
                user = await _userManager.FindByEmailAsync(UserApplicationEmail);
                result = await _userManager.ConfirmEmailAsync(user, token);
            }

            else
            {
                return View("Error");
            }

            if(user.AccountRole == ConstantRoles.School)
            {
                return View(nameof(ConfirmEmail));
            }
            else if(user.AccountRole == ConstantRoles.Spellers)
            {
                return RedirectToAction("GetAllSpellers", "School", new { Message = "You Have Succesfully Registered A Speller" });
            }
            return View("Error");
        }

        [HttpGet]
        [Route("SuccessRegistration")]
        public IActionResult SuccessRegistration( )
        {
            return View();
        }

        [HttpGet]
        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        [Route("RegisterAdmin")]
        //[Authorize(Roles ="SuperAdmin")]
        public IActionResult RegisterAdmin()
        {
          
            return View();
        }


        [HttpPost]
        [Route("RegisterAdmin")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new SchoolsApplicationUser()
                {
                    //FirstName = registerViewModel.FirstName,
                    //LastName = registerViewModel.LastName,  
                    //Genders = registerViewModel.Gender,
                    //DateOfBirth = registerViewModel.DateOfBirth,
                    //Address = registerViewModel.Address,
                    //UserName = registerViewModel.Email,
                    //Email = registerViewModel.Email,
                };


                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (!await _roleManager.RoleExistsAsync(ConstantRoles.Admin))
                    await _roleManager.CreateAsync(new IdentityRole { Name = ConstantRoles.Admin });

                if (await _roleManager.RoleExistsAsync(ConstantRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user, ConstantRoles.Admin);
                }

                if (result.Succeeded)
                {

                    if (_signInManager.IsSignedIn(User) && User.IsInRole(ConstantRoles.Admin))
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
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login(string Response)
        {
            _logger.LogInformation(Response);

            LoginViewModel loginView = new LoginViewModel
            {
                SessionResponse = Response
            };
            _logger.LogInformation(loginView.SessionResponse);
            return View(loginView);
        }
        [HttpPost("Login")]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {         
            if (ModelState.IsValid)
            {
                
                var user = await _userManager.FindByEmailAsync(loginViewModel.UserName);
                if (user == null)
                {
                    return View(nameof(UserNotFound));
                }
                else
                {
                   
                    var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.IsPersistent, false);
                    if (result.Succeeded)
                    {
                        HttpContext.Session.SetString("UserId", user.Id);
                        HttpContext.Session.SetInt32("SchoolId", user.SchoolTabId.Value);
                        HttpContext.Session.SetString("SchoolName", user.FullName);
                        if (returnUrl != null && Url.IsLocalUrl(returnUrl))
                        {
                            _logger.LogInformation("User is  Logged in");
                            return RedirectToAction(returnUrl);
                        }

                        if (await _userManager.IsInRoleAsync(user, "School"))
                        {
                           
                            await _signInManager.SignInAsync(user, isPersistent: loginViewModel.IsPersistent);
                            return RedirectToAction("SchoolsPage", "School");
                        }
                        else
                        {
                           
                            await _signInManager.SignInAsync(user, isPersistent: loginViewModel.IsPersistent);
                            _logger.LogInformation("User is  Logged in");
                            return RedirectToAction("CandidatePage", "School");
                        }
                    }
                    ModelState.AddModelError("", "Invalid Input");

                }

            }
            return View(loginViewModel);
        }
        [HttpPost]
        [Route("Logout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User is Logged out");

            return RedirectToAction("Index", "Home");
        }

     
        [HttpGet]
        [Route("CantRegister")]
        [AllowAnonymous]
        public IActionResult CantRegister(string message)
        {
            return View(message);
        }
        

      

        [HttpGet]
        [Route("UserNotFound")]
        public IActionResult UserNotFound()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("IsEmailInUsed")]
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUsed(string Email)
        {
            var result = await _userManager.FindByEmailAsync(Email);

            if (result == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"the {Email} is already in use please choose an another email ");
            }

            //return Json(result == null , JsonRequestBehavior)
        }
        [HttpPost("GetStateLocalGovt")]
        [Route("GetStateLocalGovt")]
        [AllowAnonymous]
        public IActionResult GetStateLocalGovt(int? Id)
        {

            if (Id == null)
            {
                return NotFound();
            }
            var enumdisplaystatus = (States)Id;
            string enumname = enumdisplaystatus.ToString();

            List<string> Model = new List<string>();
            StatesLocalGovt stl = new StatesLocalGovt();

            for (int i = 0; i < StatesLocalGovt.allstateslocalgovt.Count(); i++)
            {
                if (Id == i)
                {
                    Model = StatesLocalGovt.allstateslocalgovt.ElementAt(i);
                }
            }
            return Ok(new { Model, enumname, Id });
        }
       
    }
}
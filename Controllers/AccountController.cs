using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManagementwithdatabase1.Services;
using Microsoft.AspNetCore.Authorization;
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
using StudentProject.Data;
using StudentProject.Models;
using StudentProject.ViewModels;

namespace StudentProject.Controllers
{
    public class FilterLocalGovt
    {
        public int enumValue { get; set; }
    }
    
    

    public static class TempDataExtension
    {
        public static void Put<T>(this ITempDataDictionary tempData, string Key, T value) where T : class
        {
            tempData[Key] = JsonConvert.SerializeObject(value);
        }
         public static T Get<T>(this ITempDataDictionary tempData, string Key) where T : class
        {
            tempData.TryGetValue(Key, out object o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }

        public static T Peek<T>(this ITempDataDictionary tempData,string Key) where T : class
        {
            object o = tempData.Peek(Key);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }
    }

    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<SchoolApplicationUser> _userManager;
        private readonly SignInManager<SchoolApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IFileManagerService _fileservice;
        private readonly IMailService emailsender;
        private readonly SchoolApplicationDbContext _context;

        public AccountController(ILogger<AccountController> logger,
            UserManager<SchoolApplicationUser> userManager,
            SignInManager<SchoolApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            SchoolApplicationDbContext context,
            IFileManagerService fileservice,
            IMailService _emailsender
        )
        {
            this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._fileservice = fileservice;
            emailsender = _emailsender;
            this._context = context;
        }

     
     

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterSchool()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterSchool(RegisterSchoolViewModel registerViewModel)
        {
            var registeredWithinLocalGovt = _context.localGovtSchools.Select(x =>
               x.LocalGovernmentName == registerViewModel.SchoolLocalGovt)
             .Count();
            RegisterSchoolViewModel rgs1 = new RegisterSchoolViewModel();

            var candidateslogin = _userManager.FindByEmailAsync(registerViewModel.CandidatesEmail);

            //if (!(ModelState.IsValid) || registeredWithinLocalGovt == 20)
            //{
            //    rgs1.RegisterStatus = "The Registration For Schools Under " + registerViewModel.SchoolLocalGovt + " is Closed";
            //    return RedirectToAction(nameof(CantRegister));
            //}
            //if (!(ModelState.IsValid) && registeredWithinLocalGovt == 20)
            //{
            //    rgs1.RegisterStatus = "The Registration For Schools Under " + registerViewModel.SchoolLocalGovt + " is Closed";
            //    return RedirectToAction(nameof(CantRegister));
            //}

            //if (candidateslogin == null)
            //{
            //    registerViewModel.RegisterStatus = "Candidate Login info has not been Generated";
            //    return View(registerViewModel);
            //}
            if(registeredWithinLocalGovt >= 20)
            {
                var message = "The Registration For Schools Under " + registerViewModel.SchoolLocalGovt + " is Closed";
                return RedirectToAction(nameof(CantRegister),message);
            }


            if (ModelState.IsValid )
            {
               
                var enumdisplaystatus = (States)registerViewModel.SchoolState;
                string enumname = enumdisplaystatus.ToString();


                var SchoolVideo = new SchoolVideos()
                {
                    VideoPath = await _fileservice.SaveVideo(registerViewModel.VideoPath)
                };

               
                var schoolapplicationuser = new SchoolApplicationUser()
                {
                    SchoolName = registerViewModel.SchoolName,
                    SchoolState = enumname,
                    SchoolLocalGovt = registerViewModel.SchoolLocalGovt,
                    RelationShip = registerViewModel.RelationShip,               
                    Email = registerViewModel.Email,
                    PhoneNumber = registerViewModel.SchoolPhoneno,
                    UserName = registerViewModel.Email,
                    SchoolVideos = SchoolVideo,
                };

               

                var result1 = await _userManager.CreateAsync(schoolapplicationuser, registerViewModel.ConfirmSchoolPassword);

                if (!await _roleManager.RoleExistsAsync("Schools Representatives"))
                    await _roleManager.CreateAsync(new IdentityRole("Schools Representatives"));

                if (await _roleManager.RoleExistsAsync("Schools Representatives"))
                {
                    await _userManager.AddToRoleAsync(schoolapplicationuser, "Schools Representatives");
                }

                var SchoollocalGovt = new LocalGovtSchool()
                {
                    LocalGovernmentName = registerViewModel.SchoolLocalGovt,
                    SchoolName = registerViewModel.SchoolName,
                };

                _context.localGovtSchools.Add(SchoollocalGovt);
                await _context.SaveChangesAsync();

                if (result1.Succeeded)
                {

                    SchoolApplicationUser models = new SchoolApplicationUser
                    {
                        SchoolName = schoolapplicationuser.SchoolName,
                        SchoolLocalGovt = schoolapplicationuser.SchoolLocalGovt,
                        SchoolState = schoolapplicationuser.SchoolState,
                    };

                   

                    TempData.Put("Models", models);

                    return RedirectToAction(nameof(GetCandidatesLogin),new { id= schoolapplicationuser.Id});

                    //return RedirectToAction(nameof(GetCandidatesLogin), new
                    //{
                    //    //RelationShip = schoolapplicationuser.RelationShip,
                    //    id = schoolapplicationuser.Id,
                    //    SchoolName = schoolapplicationuser.SchoolName,
                    //    SchoolLocalGovt = schoolapplicationuser.SchoolLocalGovt,
                    //    SchoolState = schoolapplicationuser.SchoolState
                    //});
              
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
        public IActionResult GetCandidatesLogin()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetCandidatesLogin(GetCandidateLoginModel model, string id)
        {          
            //var registeredWithinLocalGovt = _context.localGovtSchools.Select(x =>
            //x.LocalGovernmentName == model.LocalGovt);

            if (ModelState.IsValid)
            {
                //SchoolApplicationUser schooluser = new SchoolApplicationUser()
                //{
                //    Email = model.Email,
                //    UserName = model.Email,
                //    SchoolName = SchoolModel.SchoolName,
                //    RelationShip = "Candidates",
                //    SchoolLocalGovt = "Lagos",
                //    SchoolState = "Lagos_mainland"
                //};
                var schoolmodel = TempData.Get<SchoolApplicationUser>("Models");
                SchoolApplicationUser user = new SchoolApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    SchoolName = schoolmodel.SchoolName,
                    RelationShip = "Candidates",
                    SchoolLocalGovt = schoolmodel.SchoolLocalGovt,
                    SchoolState = schoolmodel.SchoolState
                };


                TempData.Put("candidateEmail", user.Email);

                var result = await _userManager.CreateAsync(user, model.ConfirmPassword);
                if (!await _roleManager.RoleExistsAsync("Candidates"))
                    await _roleManager.CreateAsync(new IdentityRole("Candidates"));

                if (await _roleManager.RoleExistsAsync("Candidates"))
                {
                    await _userManager.AddToRoleAsync(user, "Candidates");
                }

                if (result.Succeeded)
                {
                    //ApplicationUser applicationUser = new ApplicationUser()
                    //{
                    //    FirstName = User.Identity.Name
                    //};
                    return RedirectToAction(nameof(SchoolCandidate), new
                    {
                        id = id,
                    });

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogTrace("Account/Controller");
                        _logger.LogError(error.Description);
                        ModelState.AddModelError("", error.Description);
                        return View(error);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SchoolCandidate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SchoolCandidate(SchoolCandidatesModel model, string id)
        {
            var candidateEmail = TempData.Get<string>("candidateEmail");
             var canddidates =  await _userManager.FindByEmailAsync(candidateEmail);
            SchoolApplicationUser user = await _userManager.FindByIdAsync(id);

            var candidatesnumber = model.SchoolCandidates.Count;
            var schoolcandidates = new List<SchoolCandidates>();

            if (ModelState.IsValid)
            {


                if (model.SchoolCandidates != null && model.SchoolCandidates.Count > 0)
                {
                    for (int i = 0; i < candidatesnumber; i++)
                    {
                        SchoolCandidates sc = new SchoolCandidates
                        {
                            SchoolId = id,
                            SchoolCandidate = model.SchoolCandidates.ElementAt(i).ToString(),
                        };

                        schoolcandidates.Add(sc);
                                          
                    }

                    foreach(var item in schoolcandidates)
                    {
                       
                        _context.schoolCandidates.Add(item);
                        _context.SaveChanges();
                        _context.Entry<SchoolCandidates>(item).State = EntityState.Detached;
                    }


                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirmationLink = Url.Action(nameof(ConfirmEmail),
                            "Account", new {  token, email = user.Email }, null);


                        var mailRequest = new MailRequest
                        {
                            Body = confirmationLink,
                            Subject = "Confirmation Link",
                            ToEmail = user.Email
                        };

                    await emailsender.SendEmailAsync(mailRequest);
                    canddidates.EmailConfirmed = true;

                    TempData.Put("Id", user.Id);
                    return RedirectToAction(nameof(SuccessRegistration));
                    //if (Options.SignIn.RequireConfirmedAccount == true)
                    //{
                    //    await emailsender.SendEmailAsync(mailRequest);
                    //    canddidates.EmailConfirmed = true;
                    //    return RedirectToAction(confirmationLink);
                    //    //return RedirectToPage("RegisterConfirmation", new { email = Input.Email, code, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: true);
                    //    return RedirectToAction("SchoolsPage", "School");
                    //}


                    //if (user.EmailConfirmed == true)
                    //{
                    //    canddidates.EmailConfirmed = true;
                    //}

                    //var result = await _userManager.UpdateAsync(canddidates);



                    //if(result.Succeeded)
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return RedirectToAction("SchoolsPage", "School");
                    //}

                    //else
                    //{
                    //    foreach (var error in result.Errors)
                    //    {
                    //        _logger.LogTrace("Account/Controller");
                    //        _logger.LogError(error.Description);
                    //        ModelState.AddModelError("", error.Description);
                    //        return View();
                    //    }
                    //}                                            

                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);

            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }

        [HttpGet]
        public IActionResult SuccessRegistration( )
        {

         
            return View();

        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
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
                var user = new SchoolApplicationUser()
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
        public IActionResult Login()
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
                        if (returnUrl != null && Url.IsLocalUrl(returnUrl))
                        {
                            _logger.LogInformation("User is  Logged in");
                            return RedirectToAction(returnUrl);
                        }

                        if (await _userManager.IsInRoleAsync(user, "Schools Representatives"))
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return RedirectToAction("SchoolsPage", "School");
                        }
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            _logger.LogInformation("User is  Logged in");
                            return RedirectToAction("CandidatePage", "School");
                        }

                        //else
                        //{
                        //    _logger.LogInformation("User is  Logged in");
                        //    return RedirectToAction("Index", "Home");
                        //}
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

       [HttpPost]
       [AllowAnonymous]

       public IActionResult GetStateLocalGovt( int? enumValue)
        {
           
            if(enumValue == null)
            {
                return NotFound();
            }
            var enumdisplaystatus = (States)enumValue;
            string enumname = enumdisplaystatus.ToString();

            List<string> Model = new List<string>();
            StatesLocalGovt stl = new StatesLocalGovt();

            for (int i = 0; i < StatesLocalGovt.allstateslocalgovt.Count(); i++)
            {
                if (enumValue == i)
                {
                    Model = StatesLocalGovt.allstateslocalgovt.ElementAt(i);
                }
            }
            return Ok(new {Model,enumname,enumValue});
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult CantRegister(string message)
        {
            return View(message);
        }
        

      

        [HttpGet]
        public IActionResult UserNotFound()
        {
            return View();
        }

        [AllowAnonymous]
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
    }
}
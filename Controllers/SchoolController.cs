using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Extensions.Logging;
using StudentProject.Data;
using StudentProject.Models;
using StudentProject.Models.SeedRoles;
using StudentProject.ViewModels;
using StudentProject.Services;
using StudentProject.Repositories;
using IMailService = StudentProject.Repositories.IMailService;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using System.IO;
using SQLitePCL;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Extensions.Primitives;

namespace StudentProject.Controllers
{
   
   

    [Authorize(Roles = "School")]
    [Route("api/[controller]")]
    public class SchoolController : Controller
    {
        private readonly ILogger<SchoolController> _logger;
        private readonly UserManager<SchoolsApplicationUser> _userManager;
        private readonly SignInManager<SchoolsApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;   
        private readonly ApplicationDbContext _context;
        private readonly IFileManagerService fileService;
        private readonly IMailService emailService;

        public SchoolController(ILogger<SchoolController> logger,
              UserManager<SchoolsApplicationUser> userManager,
            SignInManager<SchoolsApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context,
            IFileManagerService fileService,
            IMailService emailService
            )

        {
            _logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;       
            this._context = context;
            this.fileService = fileService;
            this.emailService = emailService;
        }


       
        [HttpGet("School")]
        [Route("School")]
        
        public IActionResult SchoolsPage()
        {

            return View();
        }

        [HttpGet("GetAllSpellers")]
        [Route("GetAllSpellers")]
        public async Task<IActionResult> GetAllSpellers(string Message)
        {
            int SchoolId;
            try
            {
                SchoolId = HttpContext.Session.GetInt32("SchoolId").Value;
            }
            catch(Exception ex)
            {
                await _signInManager.SignOutAsync();
                _logger.LogError(ex.Message);
                return RedirectToAction("Login", "Account", new { Response = "Your Current Session has expired please login again" });
            }
           
             
            string convertid = SchoolId.ToString();
            ListSpellersViewModel model = new ListSpellersViewModel();
            
            if (convertid == null)
            {
                return NotFound();
            }
            else
            {
                if(Message != null)
                {
                    ViewBag.Message = Message;
                }
                model.Spellers = _context.SpellersTabs.ToList().Where(x => x.SchoolId == SchoolId);
                model.SpellersVideos = _context.SpellersVideos.ToList().Where(x => x.SchoolId == SchoolId);
                model.SpellersImgs = _context.SpellersImgs.ToList().Where(x => x.SchoolId == SchoolId);
                //spellers = _context.SpellersVideos.ToList().Where(x=>x.s)
            }
            

            return View(model);
        }

       
        [HttpGet("RegisterSpeller")]
        [Route("RegisterSpeller")]
        public IActionResult RegisterSpeller()
        {
            return View();
        }

        [HttpPost("RegisterSpeller")]
        [Route("RegisterSpeller")]
        public async Task<IActionResult> RegisterSpeller(RegisterSpellerViewModel registerSpellerViewModel)
        {
            int schoolid;
            try
            {
                schoolid = HttpContext.Session.GetInt32("SchoolId").Value;
            }
            catch (Exception ex)
            {
                await _signInManager.SignOutAsync();
                _logger.LogError(ex.Message);
                return RedirectToAction("Login", "Account", new { Response = "Your Current Session has expired please login again" });
            }
            var schoolname = HttpContext.Session.GetString("SchoolName");
            var enumdisplaystatus = (Gender)registerSpellerViewModel.Gender;
            string enumname = enumdisplaystatus.ToString();


            if (ModelState.IsValid)
            {
                SpellersVideos spellersVideos = new SpellersVideos()
                {
                    SchoolId = schoolid,
                    SpellersName = registerSpellerViewModel.FullName,
                    DateCreated = DateTime.Now.ToString(),
                    VideoPath = await fileService.SaveVideo(registerSpellerViewModel.VideoPath)
                };

                SpellersImg spellersimage = new SpellersImg()
                {
                    SchoolId = schoolid,
                    SpellersName = registerSpellerViewModel.FullName,
                    DateCreated = DateTime.Now.ToString(),
                    ImagePath = await fileService.SaveImage(registerSpellerViewModel.ImagePath)
                };

                var SpellersTab = new SpellersTab()
                {
                    FullName = registerSpellerViewModel.FullName,
                    SchoolName = schoolname,
                    Age = registerSpellerViewModel.Age,
                    Gender = enumname,
                    DateOfBirth = registerSpellerViewModel.DateOfBirth,
                    Class = registerSpellerViewModel.Class,
                    FavouriteFood = registerSpellerViewModel.FavouriteFood,
                    FavouriteSport = registerSpellerViewModel.FavouriteSport,
                    FavouritesAuthor = registerSpellerViewModel.FavouritesAuthor,
                    FavouriteTvShow = registerSpellerViewModel.FavouriteTvShow,
                    Musician = registerSpellerViewModel.Musician,
                    ShortBio = registerSpellerViewModel.ShortBio,
                    SpellersVideos = spellersVideos,
                    SpellersImg = spellersimage,
                    SchoolId = schoolid,
                    Email = registerSpellerViewModel.Email,
                    CreatedBy = registerSpellerViewModel.CreatedBy,
                    DateCreated = DateTime.Now.ToString()
                };


                var schoolapplicationuser = new SchoolsApplicationUser()
                {
                    FullName = registerSpellerViewModel.FullName,
                    AccountRole = ConstantRoles.Spellers,
                    SchoolTabId = schoolid,
                    DateCreated = DateTime.Now.ToString(),
                    CreatedBy = registerSpellerViewModel.CreatedBy,
                    Email = registerSpellerViewModel.Email,
                    UserName = registerSpellerViewModel.Email,
                    SpellersTab = SpellersTab
                };



                var result1 = await _userManager.CreateAsync(schoolapplicationuser, registerSpellerViewModel.ConfirmPassword);


                if (!await _roleManager.RoleExistsAsync(ConstantRoles.Spellers))
                    await _roleManager.CreateAsync(new IdentityRole { Name = ConstantRoles.Spellers });

                if (await _roleManager.RoleExistsAsync(ConstantRoles.Spellers))
                {
                    await _userManager.AddToRoleAsync(schoolapplicationuser, ConstantRoles.Spellers);
                }


                if (result1.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(schoolapplicationuser);
                    var confirmationLink = Url.Action("ConfirmEmail",controller:"Account",
                         new { token, email = schoolapplicationuser.Email }, Request.Scheme);

                    var mailRequest = new MailRequest
                    {
                        Body = confirmationLink,
                        Subject = "Confirmation Link",
                        ToEmail = schoolapplicationuser.Email
                    };
                    
                    await emailService.SendEmailAsync(mailRequest);

                    TempData.Put("Token", token);
                    TempData.Put("UserApplicationEmail", schoolapplicationuser.Email);
                    TempData.Put("Id", schoolapplicationuser.Id);
                    return RedirectToAction("SuccessRegistration",controllerName:"Account");
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
            return View(registerSpellerViewModel);
        }

        [HttpGet("EditSpeller")]
        [Route("EditSpeller")]
        public async Task<IActionResult> EditSpeller(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {                             
               var schoolid = HttpContext.Session.GetInt32("SchoolId").Value;
            }
            catch (Exception ex)
            {
                 await _signInManager.SignOutAsync();
                _logger.LogError(ex.Message);
                return RedirectToAction("Login", "Account", new { Response = "Your Current Session has expired please login again" });
            }
            
            var user = _context.SpellersTabs.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            //var spellerImages = user.SpellersImg.ImagePath;
            var spellerVideo = _context.SpellersVideos.FirstOrDefault(x => x.SpellersId == user.SpellersId);
            var spellerImages = _context.SpellersImgs.FirstOrDefault(x => x.SpellersId == user.SpellersId);

            var Spellers = new EditSpellerViewModel()
            {
                Id = id.Value,
                FullName = user.FullName,
                Age = user.Age,
                DateOfBirth = user.DateOfBirth,
                Class = user.Class,
                ShortBio = user.ShortBio,
                FavouriteFood = user.FavouriteFood,
                FavouritesAuthor = user.FavouritesAuthor,
                FavouriteSport = user.FavouriteSport,
                FavouriteTvShow = user.FavouriteTvShow,
                Musician = user.Musician,
                ExistingVideoPath = spellerVideo.VideoPath,
                ExistingImagePath = spellerImages.ImagePath           
            };
            if (user.Gender == "Male")
            {
                Spellers.Gender = 0;
            }
            else
            {
                Spellers.Gender = 1;
            }

            return View(Spellers);
        }


        [HttpPost("EditSpeller")]
        [Route("EditSpeller")]
        public async Task<IActionResult> EditSpeller(int? id,EditSpellerViewModel editSpellerView)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var user = _context.SpellersTabs.FirstOrDefault(x => x.SpellersId == id);
                    SchoolsApplicationUser schooluser = await _userManager.FindByEmailAsync(user.Email);
                    var SpellerVideo = _context.SpellersVideos.FirstOrDefault(x=>x.SpellersId == user.SpellersId);
                    var spellerImage = _context.SpellersImgs.FirstOrDefault(x => x.SpellersId == user.SpellersId);
                    var enumdisplaystatus = (Gender)editSpellerView.Gender;
                    string enumname = enumdisplaystatus.ToString();

                    SpellerVideo.VideoPath = await fileService.UpdateVideo(editSpellerView);
                    SpellerVideo.DateUpdated = DateTime.Now.ToString();
                    SpellerVideo.SpellersName = editSpellerView.FullName;
                    

                    spellerImage.ImagePath = await fileService.UpdateImg(editSpellerView);
                    spellerImage.SpellersName = editSpellerView.FullName;
                    spellerImage.DateUpdated = DateTime.Now.ToString();

                    user.FullName = editSpellerView.FullName;
                    user.Age = editSpellerView.Age;
                    user.Gender = enumname;
                    user.DateOfBirth = editSpellerView.DateOfBirth;
                    user.SpellersVideos = SpellerVideo;
                    user.SpellersImg = spellerImage;
                    user.DateUpdated = DateTime.Now.ToString();
                    user.UpdatedBy = editSpellerView.UpdatedBy;

                    schooluser.SpellersTab = user;
                    schooluser.FullName = editSpellerView.FullName;                   
                    schooluser.UpdatedBy = editSpellerView.UpdatedBy;
                    schooluser.DateUpdated = DateTime.Now.ToString();

                   
                    _context.SpellersVideos.Update(SpellerVideo);
                    _context.SpellersImgs.Update(spellerImage);
                    await _context.SaveChangesAsync();
                     var result = await _userManager.UpdateAsync(schooluser);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User Profile Has been Edited");
                        return RedirectToAction(nameof(GetAllSpellers));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                }            

            }
            return View(editSpellerView);
        }
        [HttpPost("DeleteSpeller")]
        [Route("DeleteSpeller")]
        public async Task<JsonResult> DeleteSpeller(int? id)
        {
            if (id != null)
            {
                SpellersTab spelers = _context.SpellersTabs.FirstOrDefault(x=>x.SpellersId == id);
                SchoolsApplicationUser schooluser = await _userManager.FindByEmailAsync(spelers.Email);
                var SpellerVideo = _context.SpellersVideos.FirstOrDefault(x => x.SpellersId == id);
                var spellerimage = _context.SpellersImgs.FirstOrDefault(x => x.SpellersId == id);

                spelers.SpellersVideos = SpellerVideo;
                spelers.SpellersImg = spellerimage;
                schooluser.SpellersTab = spelers;
                if(SpellerVideo.VideoPath!= null || SpellerVideo.VideoPath == "Error")
                {
                    fileService.DeleteVideo(SpellerVideo.VideoPath);
    
                }
                if( spellerimage.ImagePath != null || SpellerVideo.VideoPath == "Error")
                {
                    fileService.DeleteImage(spellerimage.ImagePath);
    
                }
                var result = await _userManager.DeleteAsync(schooluser);

                if (result.Succeeded)
                {
                    _context.SpellersTabs.Remove(spelers);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("A School Spelller " + spelers.FullName + " has just been deleted");
                    ViewBag.Message = "A School Spelller " + spelers.FullName + " has just been deleted";
                    return Json(new { Status = "Successfully Deleted" });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogError(error.Description);
                        return Json("Couldn't Delete this Speller");
                    }
                }
            }
            return Json(new { Status = "The Specified Speller Was not Found" });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }       

    }
}

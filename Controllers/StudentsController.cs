using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentProject.Models;
using StudentProject.Repositories;
using StudentProject.ViewModels;

namespace StudentProject.Controllers
{

    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentRepository _repository;

        public StudentsController(ILogger<StudentsController> logger,
            IStudentRepository repository)
        {
            _logger = logger;
            this._repository = repository;
        }
        
       
        [HttpGet]
         public IActionResult RegisterStudent()
         {
            return View();
         }

        [HttpPost]
        public IActionResult RegisterStudent(RegisterStudentModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.RegisterNewStudent(model);
                return RedirectToAction(nameof(GetAllStudents));
            }

           return View(model);
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _repository.GetAllStudents();
            return View(students);
        }

        [HttpGet]
        public IActionResult GetStudentStatus()
        {
            return View();
        }


     
    }

    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase 
    {
        private readonly IStudentRepository _repository;

        public StudentApiController(IStudentRepository repository)
        {
            _repository = repository;       
        }

        [Route("PrintName")]
        public string PrintName()
        {
            return "hello";
        }

        [HttpPost]
        [Route("GetStudentStatus")]
        public IActionResult GetStudentStatus(StudentStatusViewModel model)
        {
            var status = _repository.GetStudentStatus(model);
            return Ok(status);
        }

    }
}

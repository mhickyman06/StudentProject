using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentProject.Models;

namespace StudentProject.Controllers
{
    public class EmployeesController : Controller 
    {
        public EmployeesController()
        {
            
        }
        
        public IActionResult RegisterNewStudent(){
            return View();
        }
    }
}
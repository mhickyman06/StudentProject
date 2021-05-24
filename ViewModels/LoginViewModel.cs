using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool IsPersistent { get; set; }

        public string SessionResponse { get; set; }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.ViewModels 
{
    public class RegisterSpellerViewModel
    {

        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        public string Age { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public string DateOfBirth { get; set; }

        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "IsEmailInUsed", controller: "Account", ErrorMessage = "Email is in used by another user")]
        //[Remote("UserAlreadyExistsAsync", "Account")]
        public string Email { get; set; }

        [DataType(DataType.Upload)]
        [MaxFileSize(30*1024*1024)]
        [DisplayName("Spellers Video (Optional but Video Must be within 30mb)")]
        public IFormFile VideoPath { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "The Password are not the same, please check and try agin")]
        public string ConfirmPassword { get; set; }

        //[DisplayName("Date Created")]
        //[DataType(DataType.DateTime)]
        //public string  DateCreated { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
    }

}
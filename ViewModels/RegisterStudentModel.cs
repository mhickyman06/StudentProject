using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.ViewModels
{
    public class RegisterStudentModel
    {
        [Required(ErrorMessage = "This Student FirstName is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This Student LastName is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This Student DateOfBirth is required")]
        [DisplayName("Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "This Student Age is required")]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required(ErrorMessage = "This Student Class is required")]
        public string Class { get; set; }

        [Remote(action: "IsEmailInUsed", controller: "Account")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string  Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage =" Please check your password and try again")]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }

}
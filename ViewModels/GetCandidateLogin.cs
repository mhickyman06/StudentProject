using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.ViewModels {
    public class GetCandidateLoginModel
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "IsEmailInUsed", controller: "Account", ErrorMessage = "Email is in used by another user")]
        //[Remote("UserAlreadyExistsAsync", "Account")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "The Password are not the same, please check and try agin")]
        public string ConfirmPassword { get; set; }
    }

}
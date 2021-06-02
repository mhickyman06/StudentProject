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

        [Required]
        public string Class { get; set; }

        [Required]
        [DisplayName("Short bio about the speller")]
        public string ShortBio { get; set; }

        public string Address { get; set; }
        
        [DisplayName("Favourite Author(Optional)")]
        public string FavouritesAuthor { get; set; }

        [DisplayName("Favourite Sport(Optional)")]
        public string FavouriteSport { get; set; }

        [DisplayName("Favourite TvShow(Optional)")]
        public string FavouriteTvShow { get; set; }

        [DisplayName("Favourite Musican(Optional)")]

        public string Musician { get; set; }

        [DisplayName("Favourite Food(Optional)")]
        public string FavouriteFood { get; set; }
          
        [Required]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "IsEmailInUsed", controller: "Account", ErrorMessage = "Email is in used by another user")]
        //[Remote("UserAlreadyExistsAsync", "Account")]
        public string Email { get; set; }

        [DataType(DataType.Upload)]
        [MaxFileSize(30*1024*1024)]
        [DisplayName("Spellers Video (Optional but Video Must be within 30mb)")]
        public IFormFile VideoPath { get; set; }

        [DataType(DataType.Upload)]
        [Required]
        [DisplayName("Click to Add the Speller Image")]
        public IFormFile ImagePath { get; set; }

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
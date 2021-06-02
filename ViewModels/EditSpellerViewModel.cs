using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.ViewModels
{
    public class EditSpellerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }

        
        public int Gender { get; set; }

       
        public string Age { get; set; }


       
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

        public string ExistingVideoPath { get; set; }

        public string ExistingImagePath { get; set; }

        [DisplayName("Spellers Video (Optional but Video Must be within 30mb)")]
        [MaxFileSize(30*1024*1024)]
        public IFormFile VideoPath { get; set; }

        [DisplayName("Spellers Image")]
        public IFormFile ImagePath { get; set; }

        [Required]
        public string UpdatedBy { get; set; }

       

    }

}

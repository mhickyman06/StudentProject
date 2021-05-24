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
     

        public string ExistingVideoPath { get; set; }

        [DisplayName("Spellers Video (Optional but Video Must be within 30mb)")]
        [MaxFileSize(30*1024*1024)]
        public IFormFile VideoPath { get; set; }

        [Required]
        public string UpdatedBy { get; set; }

       

    }

}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.ViewModels
{
    public class RegisterSchoolViewModel
    {
        [Required]
        [DisplayName("School Name")]
        public string SchoolName { get; set; }

        [Required]
        [DisplayName("State Where The School is Located")]
        public int SchoolState { get; set; }

        [Required]
        [DisplayName("Local Governemt of Where the School is Located")]
        public string SchoolLocalGovt { get; set; }

        [Required]
        [DisplayName("Relationship to School")]
        public string RelationShip { get; set; }


        [Required]
        [DisplayName("School Preliminary Competitions Videos(Videp size must be within 30mb")]
        [MaxFileSize(240000000)]
        public IFormFile VideoPath { get; set; }

        [Required]
        //[Remote("UserAlreadyExistsAsync","Account")]
        [Remote(action: "IsEmailInUsed", controller: "Account",ErrorMessage ="Email is in used by another user")]
        [DisplayName("School Email")]
        public string Email { get; set; }

        [DataType(DataType.EmailAddress)]
        public string CandidatesEmail { get; set; }

        [DisplayName("School Phone Number")]
        public string SchoolPhoneno { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("School Password")]
        public string SchoolPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("SchoolPassword", ErrorMessage = "the Password is not the same, please check and try again")]
        public string ConfirmSchoolPassword { get; set; }

        
        public string  RegisterStatus { get; set; }
    }

    public class SchoolCandidatesModel
    {
        [Required]
        [DisplayName("Candidate FullName")]
        public List<string> SchoolCandidates { get; set; }
    }

}
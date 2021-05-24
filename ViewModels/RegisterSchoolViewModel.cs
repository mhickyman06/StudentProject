using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using System;
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

        //[DataType(DataType.DateTime)]
        //public string DateCreated { get; set; }

        public string CreatedBy { get; set; }


        [DisplayName("School Address")]
        public string SchoolAddress { get; set; }
       
        [DisplayName("School Phone Number")]
        public string SchoolPhoneno { get; set; }

        [Required]
        [Remote(action: "IsEmailInUsed", controller: "Account",ErrorMessage ="Email is in used by another user")]
        [DisplayName("School Email")]
        public string Email { get; set; }       

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("School Password")]
        public string SchoolPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("SchoolPassword", ErrorMessage = "the Password is not the same, please check and try again")]
        public string ConfirmSchoolPassword { get; set; }

    }

    public class SchoolCandidatesModel
    {
        [Required]
        [DisplayName("Candidate FullName")]
        public List<string> SchoolCandidates { get; set; }
    }

}
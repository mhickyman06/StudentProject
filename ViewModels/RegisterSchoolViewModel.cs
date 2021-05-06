using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.ViewModels
{
    public class RegisterSchoolViewModel
    {
        [Required]
        [DisplayName("School Name")]
        public string SchoolName { get; set; }

        [DisplayName("State Where The School is Located")]
        [Required]
        public string SchoolState { get; set; }

        [DisplayName("Local Governemt of Where the School is Located")]
        [Required]
        public string SchoolLocalGovt { get; set; }

        [DisplayName("Relationship to School")]
        [Required]
        public string RelationShip { get; set; }

        [DisplayName("Schools Candidate")]
        [DataType(DataType.MultilineText)]
        public string SchoolCandidates { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("School Preliminary Competitions Videos")]
        public string VideoPath { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("School Email")]
        public string SchoolEmail { get; set; }

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

        public string School { get; set; }

        [Required]
        [DisplayName("Candidates Login UserName")]
        public string CandidateLoginUserName { get; set; }

        [DisplayName("Candidates Login Password")]
        [DataType(DataType.Password)]
        [Required]
        public string CandidatePassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Candidate Password")]
        [Compare("CandidatePassword",ErrorMessage ="The Password Are Not alike, Please Check and Try Again")]
        public string ConfirmCandidatePassword { get; set; }

      

      
    }

}
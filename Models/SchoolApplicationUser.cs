using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.Models
{
    public enum Gender
    {
        Male =0,
        Female =1
    }
    public enum States
    {
       Abia = 0,
       Adamawa = 1,
       AkwaIbom = 2,
       Anambra = 3,
       Bauchi = 4,
       Bayelsa = 5,
       Benue = 6,
       Borno = 7,
       CrossRiver = 8,
       Delta = 9,
       Ebonyi = 10,
       Edo = 11,
       Ekiti = 12,
       Enugu  = 13,
       Gombe = 14,
       Imo = 15,
       Jigawa = 16,
       Kaduna = 17,
       Katsina = 18,
       Kano = 19,
       Kebbi = 20,
       Kogi = 21,
       Kwara = 22,
       Lagos = 23,
       Nassarawa = 24,
       Niger = 25,
       Ogun = 26,
       Ondo = 27,
       Osun = 28,
       Oyo = 29,
       Plateau = 30,
       Rivers = 31,
       Sokoto = 32,
       Taraba = 33,
       Yobe = 34,
       Zamfara = 35
    }
   
    public class SchoolApplicationUser : IdentityUser
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
        public string RalationShip { get; set; }

        [DisplayName("Schools Candidate")]
        [DataType(DataType.MultilineText)]
        public string  SchoolCandidates { get; set; }

        public string VideoPath { get; set; }


        [Required]
        public string CandidateLoginUserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string CandidateLoginPassword { get; set; }

        public virtual CandidatesApplicationUser CandidatesApplicationUser { get; set; }

        public virtual LocalGovtSchool LocalGovtSchools { get; set; }
    }
}
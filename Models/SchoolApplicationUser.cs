using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public class SchoolVideos
    {
        [Key]
        [ForeignKey("SchoolApplicationUser")]
        public string SchoolApplicationUserId { get; set; }

        [Required]
        public string VideoPath { get; set; }

        public DateTime CreatedAt = DateTime.Now;

        //[ForeignKey("SchoolApplicationUser")]
        public virtual SchoolApplicationUser schoolApplicationUser { get; set; }
    }
    public class SchoolApplicationUser : IdentityUser
    {

        [Required]
        [DisplayName("School Name")]
        public string SchoolName { get; set; }

        [Required]
        [DisplayName("State Where The School is Located")]
        public string SchoolState { get; set; }

        [Required]
        [DisplayName("Local Governemt of Where the School is Located")]
        public string SchoolLocalGovt { get; set; }

        [Required]
        [DisplayName("Relationship to School")]
        public string RelationShip { get; set; }

        //[DisplayName("Schools Candidate")]
        //[DataType(DataType.MultilineText)]
        //public string  SchoolCandidates { get; set; }

        //public string VideoPath { get; set; }


        //[Required]
        //public string CandidateLoginUserName { get; set; }
        
        //[Required]
        //[DataType(DataType.Password)]
        //public string CandidateLoginPassword { get; set; }

        public virtual SchoolVideos SchoolVideos { get; set; }
        public virtual ICollection<SchoolCandidates> SchoolCandidates { get; set; }

    }
}
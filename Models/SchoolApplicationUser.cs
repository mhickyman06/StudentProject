using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentProject.Models
{  
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
    public class SchoolsApplicationUser : IdentityUser
    {
        [MaxLength(150)]
        [DefaultValue("")]
        public string FullName { get; set; }
        [MaxLength(120)]
        [DefaultValue("")]
        public string AccountRole { get; set; }
        [DefaultValue(false)]
        public Boolean FirstLogIn { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public string DateCreated { get; set; }

       

        [Required]
        [DefaultValue("")]
        public string CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public string DateUpdated { get; set; }

        public string UpdatedBy { get; set; }

        [ForeignKey("SchoolTab")]
        public int? SchoolTabId { get; set; }
        public SchoolTab SchoolTab { get; set; }

        public  SpellersTab SpellersTab { get; set; }

    }
}
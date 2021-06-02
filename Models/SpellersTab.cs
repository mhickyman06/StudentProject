using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentProject.Models
{
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
    public class SpellersImg 
    {
        [Key]
        [ForeignKey("SpellersTab")]
        public int SpellersId { get; set; }
        //public int SpellerId { get; set; }
        [Required]
        public string SpellersName { get; set; }

        public int SchoolId { get; set; }
        public  string ImagePath { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public string DateUpdated { get; set; }

        public virtual SpellersTab SpellersTab { get; set; }

    }

    public class SpellersVideos
    {
        [Key]
        [ForeignKey("SpellersTab")]
        public int SpellersId { get; set; }
        [Required]
        public string SpellersName { get; set; }

        public int SchoolId { get; set; }
        public virtual string VideoPath { get; set; }
        [Required]

        [DataType(DataType.DateTime)]
        public string DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public string DateUpdated { get; set; }

        public virtual SpellersTab SpellersTab {get; set;}

    }
    public class SpellersTab
    {
        [Key]
        public int SpellersId { get; set; }

        [Required]
        public int SchoolId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }


        [Required]
        public string DateCreated { get; set; }


        [DataType(DataType.DateTime)]
        public string DateUpdated { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Required]

        public string ShortBio { get; set; }

        public string FavouritesAuthor { get; set; }

        public string FavouriteSport { get; set; }

        public string FavouriteTvShow { get; set; }

        public string Musician { get; set; }

        public string FavouriteFood { get; set; }

        public virtual SpellersVideos SpellersVideos { get; set; }

        public virtual SpellersImg SpellersImg  { get; set; }

        //public virtual SpellersImg SpellersImgs { get; set; }
        //public virtual SchoolsApplicationUser SchoolsApplicationUser { get; set; }

    }
}
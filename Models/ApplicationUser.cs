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
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This Student Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "This Student DateOfBirth is required")]
        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [Required]
        public Gender Genders { get; set; }
        [Required]
        public string Address { get; set; }

        public string Class { get; set; }
    }
}
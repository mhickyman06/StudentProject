using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.Models
{
    public enum Gender
    {
        Male ,
        Female
    }
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage ="This Student FirstName is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This Student LastName is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This Student DateOfBirth is required")]
        [DisplayName("Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "This Student Age is required")]
        public int Age { get; set; }

        [Required]
        public Gender Genders { get; set; }


        [Required(ErrorMessage = "This Student Class is required")]
        public string Class { get; set; }

        [Required(ErrorMessage = "This Student Gender is required")]

        public virtual Address Address {get; set;}

    }
}

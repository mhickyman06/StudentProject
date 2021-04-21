using StudentProject.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.ViewModels
{
    public class RegisterStudentModel
    {
        [Required(ErrorMessage = "This Student FirstName is required")]
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

        [Required(ErrorMessage = "This Student Class is required")]
        public string Class { get; set; }

        [Required(ErrorMessage = "This Student Address is required")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City  is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State  is required")]
        public string State { get; set; }

        [Required]
        public Gender Gender { get; set; }

    }

}
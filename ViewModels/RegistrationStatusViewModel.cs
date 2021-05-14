using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.ViewModels
{
    public class RegistrationStatusViewModel
    {
        [Required]
        public string localGovt { get; set; }

    }
}
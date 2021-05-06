using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentProject.Models
{ 
    public class CandidatesApplicationUser: IdentityUser
    {
       

        [ForeignKey("Id")]
        public virtual SchoolApplicationUser SchoolApplicationUser { get; set; }

    }
}
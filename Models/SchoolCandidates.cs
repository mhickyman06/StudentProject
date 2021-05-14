using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentProject.Models
{
    public class SchoolCandidates
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //[ForeignKey("SchoolApplicationUser")]
        public Guid Id { get; set; }

        [ForeignKey("SchoolApplicationUser")]
        public string SchoolId { get; set; }
        public string SchoolCandidate { get; set; }
        public virtual SchoolApplicationUser SchoolApplicationUser { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentProject.Models
{   
    public class Address
    {
        [Key]
        [ForeignKey("Id")]
        public int UserId { get; set; }
       
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        //public virtual ApplicationUser ApplicationUser { get; set; }
        //public virtual Student Student { get; set; }

    }
}
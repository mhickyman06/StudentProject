using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProject.Models
{
    public class SchoolTab
    {
        [Key]
        public int Id { get; set; }
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

        [DisplayName("School Address")]
        public string SchoolAddress { get; set; }
    }
}

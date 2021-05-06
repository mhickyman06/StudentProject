using System;
using System.Collections.Generic;

namespace StudentProject.Models
{
    public class LocalGovtSchool
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SchoolApplicationUser> Schools { get; set; }
    }
}

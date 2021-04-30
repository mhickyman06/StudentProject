
using System.ComponentModel.DataAnnotations;

namespace StudentProject.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
        
    }
}
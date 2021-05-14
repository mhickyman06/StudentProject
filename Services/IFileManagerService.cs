using StudentProject.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementwithdatabase1.Services
{
      public  interface IFileManagerService
    {
         public Task<string> SaveVideo(IFormFile file);
        public void DeleteImage(EditViewModel editView);
    }
}

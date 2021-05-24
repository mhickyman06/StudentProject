using StudentProject.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProject.Services
{
      public  interface IFileManagerService
    {
         public Task<string> SaveVideo(IFormFile file);

        public Task<string> UpdateVideo(EditSpellerViewModel edit);
        public void DeleteVideo(EditSpellerViewModel editView);

        public void DeleteVideo(string videopath);
    }
}

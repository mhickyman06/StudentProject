
using StudentProject.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementwithdatabase1.Services
{
    public class FileService : IFileManagerService
    {
        public ILogger _Logger { get; }

        public FileService(IConfiguration configuration
        ,ILogger<FileService> Logger)
        {
            _videopath = configuration["Path:Videos"];
            this._Logger=Logger;

        }

        public string _videopath { get; }

        public void DeleteImage(EditViewModel editView)
        {
            try{
            var save_path = Path.Combine(_videopath,editView.ExistingPhotoPath);
            File.Delete(save_path);
            }catch{
                _Logger.LogInformation("Error");
            }
        }

        public async Task<string> SaveVideo(IFormFile video)
        {
            try
            {
                var save_path = Path.Combine(_videopath);
                if (!Directory.Exists(_videopath))
                {
                    Directory.CreateDirectory(save_path);
                }
                var filename = new Guid() + video.FileName;
                using (var filestream = new FileStream(Path.Combine(save_path, filename), FileMode.Create))
                {
            
                    await video.CopyToAsync(filestream);
                
                }
            
                return filename;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error";
            }
        }
       
    }
}

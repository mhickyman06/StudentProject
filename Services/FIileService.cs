
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using StudentProject.ViewModels;
using System.Runtime.InteropServices;

namespace StudentProject.Services
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

        public void DeleteVideo(string videopath)
        {
            try
            {
                var save_path = Path.Combine(_videopath, videopath);
                //if (Directory.Exists(save_path))
                //{
                //    File.Delete(save_path);
                //    Directory.Delete(save_path);
                //}
                if (System.IO.File.Exists(videopath))
                {
                    System.IO.File.Delete(videopath);
                }

            }
            catch
            {
                _Logger.LogInformation("Error");
            }
        }
        public void DeleteVideo(EditSpellerViewModel editView)
        {
            try
            {
                var save_path = Path.Combine(_videopath, editView.ExistingVideoPath);
                if (Directory.Exists(save_path))
                {
                    File.Delete(save_path);
                    Directory.Delete(save_path);
                }
            }
            catch
            {
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
                var guid = Guid.NewGuid();
                var filename = guid + video.FileName;
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

        public async Task<string> UpdateVideo(EditSpellerViewModel editSpeller)
        {
            if(editSpeller.VideoPath != null)
            {
                DeleteVideo(editSpeller);
                var filename = await SaveVideo(editSpeller.VideoPath);
                return filename;
            }
            return editSpeller.ExistingVideoPath;
        }
    }
}

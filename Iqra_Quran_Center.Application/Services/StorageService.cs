using Iqra_Quran_Center.Application.Abstractions.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Services
{
    public class StorageService (string webRootPath) : IStorageService
    {
        public Task<string> DeleteFileAsync(string filePath)
        {
            var fullPath = String.Concat(webRootPath, filePath);

            File.Delete(fullPath); 

            return Task.FromResult(fullPath);
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var filePath = string.Concat(Guid.NewGuid(), file.FileName);

            var fullPath = string.Concat(GetPhysicalPath(), filePath);

            using var fs = new FileStream(fullPath, FileMode.Create);

            await file.CopyToAsync(fs);

            return GetVirtualPath() + filePath;
        }

        public async Task<List<string>> SaveFilesAsync(IFormFileCollection files)
        {
            List<string> paths = new List<string>();


            foreach (var file in files)
            {
                paths.Add(await SaveFileAsync(file));
            }

            return paths;
        }



        #region Utilis
        private string GetPhysicalPath()
        {
            if (!Path.Exists(webRootPath + GetVirtualPath()))
                Directory.CreateDirectory(webRootPath + GetVirtualPath());


            return webRootPath + GetVirtualPath();
        }
        private string GetVirtualPath() => "/Files/";

        #endregion Utilis

    }
}

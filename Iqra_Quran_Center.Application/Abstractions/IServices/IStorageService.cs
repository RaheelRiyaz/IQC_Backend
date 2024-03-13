using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IServices
{
    public interface IStorageService
    {
        Task<string> SaveFileAsync(IFormFile file);
        Task<string> DeleteFileAsync(string filePath);
        Task<List<string>> SaveFilesAsync(IFormFileCollection files);
    }
}

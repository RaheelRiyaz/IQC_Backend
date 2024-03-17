using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IServices
{
    public class FileService(IStorageService service, IAppFilesRepository repository) : IFileService
    {
        public async Task<int> DeleteFileAsync(AppFile model)
        {
            var res = await repository.DeleteAsync(model);

            if(res == 0)
                return 0;

            await service.DeleteFileAsync(model.FilePath); 
            return 1;
        }

        public async Task<string> InsertFileAsync(AppFileRequest model)
        {
            var filePath = await service.SaveFileAsync(model.File);
            var appFile = new AppFile
            {
                FilePath = filePath,
                Module = model.Module,
                EntityId = model.EntityId,
            };

            var res = await repository.AddAsync(appFile);

            return res > 0 ? filePath : string.Empty;
        }
    }
}

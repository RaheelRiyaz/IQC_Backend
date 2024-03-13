using Iqra_Quran_Center.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
    public record AppFileRequest(Guid EntityId,IFormFile File,Module Module);
    
}

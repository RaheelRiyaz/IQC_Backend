using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
    public record GroupRequest(string Name,String Batch);
    public record UpdateGroupRequest(Guid Id,string Name,String Batch,bool IsActive);
    public record GroupResponse(string Name,bool IsActive,string Batch) : GroupRequest(Name,Batch);
}

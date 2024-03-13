using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IRepository
{
    public interface IGroupClassScheduleRepository : IBaseRepository<GroupClassSchedule>
    {
        Task<IEnumerable<GroupClassScheduleResponse>> ViewScheduleByGroupId(Guid groupid);
        Task<IEnumerable<GroupClassScheduleResponse>> ViewScheduleByTeacherId(Guid teacherId);
    }
}

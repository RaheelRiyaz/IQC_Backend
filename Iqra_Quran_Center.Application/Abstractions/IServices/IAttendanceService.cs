using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IServices
{
    public interface IAttendanceService
    {
        Task<APIResponse<int>> Attendance(AttendanceRequest model);
        Task<APIResponse<int>> UpdateStudentAttendance(UpdateAttendanceRequest model);
        Task<APIResponse<IEnumerable<AttendanceResponse>>> ViewAttendances(CheckAttendanceRequest model);
    }
}

using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iqra_Quran_Center.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController (IAttendanceService service) : ControllerBase
    {
        [HttpPost]
        public async Task<APIResponse<int>> Attendance(AttendanceRequest model) =>
            await service.Attendance(model);


        [HttpPut]
        public async Task<APIResponse<int>> UpdateStudentAttendance(UpdateAttendanceRequest model) =>
            await service.UpdateStudentAttendance(model);


        [HttpPost("check-attendance")]
        public async Task<APIResponse<IEnumerable<AttendanceResponse>>> ViewAttendances(CheckAttendanceRequest model) =>
            await service.ViewAttendances(model);
    }
}

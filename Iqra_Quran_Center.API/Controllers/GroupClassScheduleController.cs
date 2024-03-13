using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iqra_Quran_Center.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupClassScheduleController (IGroupClassScheduleService service) : ControllerBase
    {
        [HttpPost]
        public async Task<APIResponse<GroupClassSchedule>> AddGroupSchedule(GroupClassScheduleRequest model) =>
            await service.AddGroupSchedule(model);


        [HttpGet("{groupId:guid?}")]
        public async Task<APIResponse<IEnumerable<GroupClassScheduleResponse>>> ViewSchedulesByGroupId(Guid? groupId) =>
            await service.ViewSchedulesByGroupId(groupId);


        [HttpGet("teacher/{teacherId:guid?}")]
        public async Task<APIResponse<IEnumerable<GroupClassScheduleResponse>>> ViewSchedulesByTeacherId(Guid? teacherId) =>
           await service.ViewSchedulesByTeacherId(teacherId);
    }
}

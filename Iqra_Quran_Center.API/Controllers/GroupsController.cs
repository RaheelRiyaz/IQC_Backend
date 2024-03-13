using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iqra_Quran_Center.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController (IGroupService service) : ControllerBase
    {
        [HttpGet]
        public async Task<APIResponse<IEnumerable<GroupResponse>>> Groups () =>
            await service.Groups ();


        [HttpGet("{id:guid}")]
        public async Task<APIResponse<GroupResponse>> GroupById(Guid id) =>
           await service.GroupById(id);



        [HttpPost]
        public async Task<APIResponse<GroupResponse>> AddGroup(GroupRequest model) =>
            await service.AddGroup(model);


        [HttpPut("assign-group")]
        public async Task<APIResponse<int>> AssignGroupToStudent(AssignGroupRequst model) =>
            await service.AssignGroupToStudent(model);


        [HttpPut]
        public async Task<APIResponse<int>> UpdateGroup(UpdateGroupRequest model) =>
            await service.UpdateGroup(model);
    }
}

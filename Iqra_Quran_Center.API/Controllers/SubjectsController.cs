using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iqra_Quran_Center.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController (ISubjectsService service) : ControllerBase
    {
        [HttpGet]
        public async Task<APIResponse<IEnumerable<SubjectsResponse>>> ViewSubjects() =>
            await service.ViewSubjects();


        [HttpGet("{id:guid}")]
        public async Task<APIResponse<SubjectsResponse>> ViewSubjectById(Guid id) =>
            await service.ViewSubjectById(id);


        [HttpPost]
        public async Task<APIResponse<SubjectsResponse>> AddSubject(SubjectRequest model) =>
            await service.AddSubject(model);


        [HttpPut]
        public async Task<APIResponse<int>> UpdateSubject(UpdateSubjectsRequest model) =>
            await service.UpdateSubject(model);


        [HttpGet("group/{groupId:guid?}")]
        public async Task<APIResponse<IEnumerable<SubjectWithTeacherName>>> ViewSubjectsByGroupId(Guid? groupId) =>
            await service.ViewSubjectsByGroupId(groupId);
    }
}

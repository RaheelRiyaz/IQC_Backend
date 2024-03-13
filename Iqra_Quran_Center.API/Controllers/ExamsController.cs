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
    public class ExamsController(IExamsService service, IStorageService storageService) : ControllerBase
    {
        [HttpPost]
        public async Task<APIResponse<int>> AddExam(ExamRequest model) =>
            await service.AddExam(model);


        [HttpPut]
        public async Task<APIResponse<int>> ChangeExamStatus(ExamStatusRequest model) =>
            await service.UpdateChangeExam(model);



        [HttpGet("exam/{groupId:guid?}")]
        public async Task<APIResponse<IEnumerable<ExamResponse>>> ViewExamsByGroupId(Guid? groupId) =>
            await service.ViewExamsByGroupId(groupId);



        [HttpGet]
        public async Task<APIResponse<IEnumerable<ExamResponse>>> ViewExams() =>
            await service.ViewExams();



        [HttpPost("attend-exam")]
        public async Task<APIResponse<int>> AttendExam(ExamAttendingRequest model) =>
            await service.AttendExam(model);



        [HttpGet("view-questionpaper")]
        public async Task<APIResponse<QuestionWithAnswersResponse>> QuestionWithAnswers(Guid examId) =>
            await service.QuestionWithAnswers(examId);
    }
}

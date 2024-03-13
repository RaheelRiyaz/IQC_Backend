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
    public class QuestionsController (IQuestionsService service) : ControllerBase
    {
        [HttpPost]
        public async Task<APIResponse<int>> AddQuestion(QuestionRequest model) =>
            await service.AddQuestion(model);


        [HttpGet("exam/{examId:guid}")]
        public async Task<APIResponse<IEnumerable<QuestionPaper>>> QuestionpaperbyExamId(Guid examId) =>
            await service.QuestionpaperbyExamId(examId);


        [HttpPut]
        public async Task<APIResponse<int>> UpdateQuestion(UpdateQuestionRequest model) =>
            await service.UpdateQuestion(model);
    }
}

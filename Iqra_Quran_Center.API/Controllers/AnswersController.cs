using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iqra_Quran_Center.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController (IAnswersService service) : ControllerBase
    {
        [HttpPost]
        public async Task<APIResponse<int>> AddAnswerToQuestion(AnswerRequest model) =>
            await service.AddAnswerToQuestion(model);



        [HttpGet("question/{questionId:guid}")]
        public async Task<APIResponse<IEnumerable<AnswerResponse>>> AnswersByQuestionId(Guid questionId) =>
            await service.AnswersByQuestionId(questionId);


        [HttpPut]
        public async Task<APIResponse<int>> UpdateAnswer(UpdateAnswerRequest model) =>
            await service.UpdateAnswer(model);
    }
}

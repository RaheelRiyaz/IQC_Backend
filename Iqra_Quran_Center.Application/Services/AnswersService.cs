using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Services
{
    public class AnswersService(IAnswersRepository repository) : IAnswersService
    {
        public async Task<APIResponse<int>> AddAnswerToQuestion(AnswerRequest model)
        {
            var answer = new Answer
            {
                Content = model.Content,
                IsCorrect = model.IsCorrect,
                QuestionId = model.QuestionId
            };

            var res = await repository.AddAsync(answer);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Answer added to this questuon");

            return APIResponse<int>.ErrorResponse();
        }




        public async Task<APIResponse<IEnumerable<AnswerResponse>>> AnswersByQuestionId(Guid questionId)
        {
            var answers = await repository.FilterAsync(_ => _.QuestionId == questionId);

            return APIResponse<IEnumerable<AnswerResponse>>.SuccessResponse
                (
                answers.Select(_ => new AnswerResponse(_.QuestionId,_.Id, _.Content))
                );
        }




        public async Task<APIResponse<int>> UpdateAnswer(UpdateAnswerRequest model)
        {
            var answer = await repository.GetByIdAsync(model.Id);

            if (answer is null)
                return APIResponse<int>.ErrorResponse("No Answer found");

            if (model.IsCorrect)
               await repository.MakeAllAnswersFalse(model.QuestionId);

            answer.UpdatedOn = DateTime.Now;
            answer.Content = model.Content;
            answer.IsCorrect = model.IsCorrect;

            var res = await repository.UpdateAsync(answer);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Answer Updated Successfully");

            return APIResponse<int>.ErrorResponse();
        }
    }
}

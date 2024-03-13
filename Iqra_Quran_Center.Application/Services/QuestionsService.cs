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
    public class QuestionsService(IQuestionsRepository repository) : IQuestionsService
    {
        public async Task<APIResponse<int>> AddQuestion(QuestionRequest model)
        {
            var question = new QuestionPaper
            {
                ExamId = model.ExamId,
                QuestionTitle = model.QuestionTitle
            };

            var res = await repository.AddAsync(question);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Question added successfully");

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<IEnumerable<QuestionPaper>>> QuestionpaperbyExamId(Guid examId)
        {
            var questions = await repository.FilterAsync(_ => _.ExamId == examId);

            return APIResponse<IEnumerable<QuestionPaper>>.SuccessResponse(questions);
        }

        public async Task<APIResponse<int>> UpdateQuestion(UpdateQuestionRequest model)
        {
            var question = await repository.GetByIdAsync(model.Id);

            if (question is null)
                return APIResponse<int>.ErrorResponse("No question found");

            question.QuestionTitle = model.QuestionTitle;
            question.UpdatedOn = DateTime.Now;


            var res = await repository.UpdateAsync(question);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Question Updated Successfully");


            return APIResponse<int>.ErrorResponse();
        }
    }
}

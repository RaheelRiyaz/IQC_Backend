using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IServices
{
    public interface IQuestionsService
    {
        Task<APIResponse<int>> AddQuestion(QuestionRequest model);
        Task<APIResponse<IEnumerable<QuestionPaper>>> QuestionpaperbyExamId(Guid examId);
        Task<APIResponse<int>> UpdateQuestion(UpdateQuestionRequest model);
    }
}

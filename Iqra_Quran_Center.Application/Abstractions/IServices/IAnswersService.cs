using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IServices
{
    public interface IAnswersService
    {
        Task<APIResponse<int>> AddAnswerToQuestion(AnswerRequest model);
        Task<APIResponse<IEnumerable<AnswerResponse>>> AnswersByQuestionId(Guid questionId);
        Task<APIResponse<int>> UpdateAnswer(UpdateAnswerRequest model);
    }
}

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
    public interface IExamsService
    {
        Task<APIResponse<int>> AddExam(ExamRequest model);
        Task<APIResponse<int>> UpdateChangeExam(ExamStatusRequest model);
        Task<APIResponse<IEnumerable<ExamResponse>>> ViewExamsByGroupId(Guid? groupId);
        Task<APIResponse<IEnumerable<ExamResponse>>> ViewExams();
        Task<APIResponse<QuestionWithAnswersResponse>> QuestionWithAnswers(Guid examId);
        Task<APIResponse<int>> AttendExam(ExamAttendingRequest model);
    }
}

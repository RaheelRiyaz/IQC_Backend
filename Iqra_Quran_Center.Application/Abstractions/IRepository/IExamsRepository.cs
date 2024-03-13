using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IRepository
{
    public interface IExamsRepository : IBaseRepository<Exam>
    {
        Task<IEnumerable<ExamResponse>> ViewExamsByGroupId(Guid groupId);
        Task<IEnumerable<ExamResponse>> ViewExams();
    }

}

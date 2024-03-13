using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IRepository
{
    public interface IAnswersRepository : IBaseRepository<Answer>
    {
        Task<int> MakeAllAnswersFalse(Guid questionId);
        Task<IEnumerable<Answer>> ViewAnswersByQuestionId(Guid questionId);
    }
}

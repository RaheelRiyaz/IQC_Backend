using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IRepository
{
    public interface ISubjectsRepository : IBaseRepository<Subject>
    {
        Task<IEnumerable<SubjectWithTeacherName>> ViewSubjectsByGroupId(Guid groupId);
    }
}

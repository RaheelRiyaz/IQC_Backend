using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using Iqra_Quran_Center.Persistence.Dapper;
using Iqra_Quran_Center.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Persistence.Repository
{
    public class ExamsRepository : BaseRepository<Exam>, IExamsRepository
    {
        private const string baseQuery = $@"SELECT E.Id,GroupId,SubjectId,ExamDateTime,
                            ExamStatus,TotalMarks,PassingMarks,Title,TotalNoOfQuestions,
                            S.[Name] as [Subject]
                            FROM Exams E
                            INNER JOIN Subjects S
                            ON E.SubjectId = S.Id ";
        public ExamsRepository(IqraQuranCenterDbContext dbContext) : base(dbContext) { }

        public Task<IEnumerable<ExamResponse>> ViewExams()
        {
            return dbContext.QueryAsync<ExamResponse>(baseQuery);
        }

        public async Task<IEnumerable<ExamResponse>> ViewExamsByGroupId(Guid groupId)
        {
            string query = $@"{baseQuery} 
                            WHERE GroupId = @groupId ";

            return await dbContext.QueryAsync<ExamResponse>(query, new { groupId });
        }
    }
}

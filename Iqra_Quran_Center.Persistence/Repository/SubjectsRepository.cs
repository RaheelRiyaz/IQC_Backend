using Iqra_Quran_Center.Application.Abstractions.IRepository;
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
    public class SubjectsRepository : BaseRepository<Subject> , ISubjectsRepository
    {
        public SubjectsRepository(IqraQuranCenterDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<SubjectWithTeacherName>> ViewSubjectsByGroupId(Guid groupId)
        {
            string query = $@"SELECT S.Id,S.[Name] AS [Subject],
                                T.[Name] AS Teacher 
                                FROM GroupClassSchedules GS
                                INNER JOIN Subjects S
                                ON GS.SubjectId = S.Id
                                INNER JOIN Users T
                                ON T.Id = GS.TeacherId
                                WHERE GS.GroupId = @groupId ";

            return await dbContext.QueryAsync<SubjectWithTeacherName>(query, new { groupId });
        }
    }
}

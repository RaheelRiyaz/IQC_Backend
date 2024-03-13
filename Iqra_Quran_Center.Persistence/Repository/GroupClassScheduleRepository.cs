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
    public class GroupClassScheduleRepository : BaseRepository<GroupClassSchedule> ,IGroupClassScheduleRepository
    {
        private const string baseQuery = $@"SELECT
                            GS.Id AS ScheduleId,
                            G.Id as GroupId,
                            TeacherId,
                            SubjectId,
                            S.[Name] as SubjectName,
                            U.Email as TeacherEmail,
                            U.Name as TeacherName,
                            G.[Name] AS GroupName,
                            CONVERT(varchar(15),CAST([From] AS TIME),100) as StartTime,
	                        CONVERT(varchar(15),CAST([To] AS TIME),100) as EndTime,
                            [Day]
                        FROM
                            GroupClassSchedules GS
                        INNER JOIN
                            Subjects S ON GS.SubjectId = S.Id
                        INNER JOIN
                            Users U ON U.Id = GS.TeacherId
                        INNER JOIN
                            Groups G ON G.Id = GS.GroupId  ";


        public GroupClassScheduleRepository(IqraQuranCenterDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<GroupClassScheduleResponse>> ViewScheduleByGroupId(Guid groupid)
        {
            string query = $@"{baseQuery} WHERE
                            G.Id = @groupId 
	                        ORDER BY [DAY] ";


            return await dbContext.QueryAsync<GroupClassScheduleResponse>(query, new { groupid });
        }


        public async Task<IEnumerable<GroupClassScheduleResponse>> ViewScheduleByTeacherId(Guid teacherId)
        {
            string query = $@"{baseQuery} WHERE
                            TeacherId = @teacherId 
	                        ORDER BY [DAY] ";

            return await dbContext.QueryAsync<GroupClassScheduleResponse>(query, new { teacherId });
        }
    }
}

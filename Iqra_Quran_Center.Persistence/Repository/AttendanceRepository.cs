using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using Iqra_Quran_Center.Persistence.Dapper;
using Iqra_Quran_Center.Persistence.Data;
using System.Text;

namespace Iqra_Quran_Center.Persistence.Repository
{
    public class AttendanceRepository : BaseRepository<Attendance> ,IAttendanceRepository
    {
        public AttendanceRepository(IqraQuranCenterDbContext dbContext) : base(dbContext) { }

        public Task<IEnumerable<AttendanceCheckModel>> CheckNoOfStudents(Guid classId)
        {
            string query = $@"SELECT Id,Name FROM Users U INNER JOIN
                                (SELECT GroupId FROM GroupClassSchedules
                                WHERE Id = @classId)
                                G ON U.GroupId = G.GroupId ";


            return dbContext.QueryAsync<AttendanceCheckModel>(query, new { classId });
        }

        public async Task<IEnumerable<AttendanceResponse>> ViewAttendance(CheckAttendanceRequest model)
        {
            StringBuilder query = new StringBuilder($@"SELECT A.*, S.[Name] FROM Attendances A
                        INNER JOIN Users S ON S.Id = A.StudentId
                        WHERE ClassId = @classId");

            if (model.Date is null)
            {
                query.Append(" AND Date = (SELECT TOP 1 [Date] FROM Attendances ORDER BY Date DESC)");
            }
            else
            {
                query.Append(" AND Date = @date");
            }

            DateTime? dateParameter = Convert.ToDateTime(model.Date);

            return await dbContext.QueryAsync<AttendanceResponse>(query.ToString(), new { model.ClassId, Date = dateParameter});
        }

    }
}

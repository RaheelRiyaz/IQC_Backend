using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using Iqra_Quran_Center.Persistence.Dapper;
using Iqra_Quran_Center.Persistence.Data;
using System.Text;

namespace Iqra_Quran_Center.Persistence.Repository
{
    public class StudentFeesHistory : BaseRepository<StudentFeeHistory>, IStudentFeesHistoryRepository
    {

        public StudentFeesHistory(IqraQuranCenterDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<StudentFeeHistoryResponse>> ViewStudentFeeHistory(StudentFeeHistoryFilterRequest model)
        {
            var baseQuery = new StringBuilder($@"SELECT SH.Id,StudentId,[Date],U.[Name],
                                                    G.[Name] AS GroupName,G.Id GroupId,
                                                    TotalFeeSubmitted,PaymentMethod,
                                                    GF.TotalFee,
                                                    ((GF.TotalFee)-TotalFeeSubmitted ) AS Balance
                                                    FROM StudentFeeHistory SH
                                                    INNER JOIN Users U
                                                    ON U.Id = StudentId
                                                    INNER JOIN Groups G
                                                    ON G.Id = GroupId
                                                    INNER JOIN GroupFees GF
                                                    ON GF.GroupId = G.Id ");

            if(model.GroupId is not null)
                baseQuery.Append($@"WHERE G.Id = @groupId ");

            if (model.StudentId is not null)
                baseQuery.Append($@"AND StudentId = @studentId ");

            if (model.Date is not null)
                baseQuery.Append($@" AND [Date] = @date");

            DateTime? dateParameter = Convert.ToDateTime(model.Date);

            return await dbContext.QueryAsync<StudentFeeHistoryResponse>(baseQuery.ToString(),
                new { GroupId = model.GroupId, Studentid = model.StudentId, Date = dateParameter });
        }
    }
}

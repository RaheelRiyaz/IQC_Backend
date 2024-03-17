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
    public class ResultsRepository : BaseRepository<Result>,IResultsRepository
    {
        public ResultsRepository(IqraQuranCenterDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<ResultResponse> ViewResult(ResultFilterRequest model)
        {
            string query = $@"SELECT R.Id,StudentId,ExamId,
	                            TotalNoOfQuestions,Attempts,
	                            MarksObtained,PassingMarks,
	                            HasQualified,GroupId,TotalMarks,
	                            ExamDateTime
	                            FROM Results R
	                            INNER JOIN Exams E
	                            ON E.Id = R.ExamId
	                            WHERE StudentId = @studentId
	                            AND ExamId = @examId AND
	                            ExamStatus = 1";

            return await dbContext.FirstOrdefaultAsync<ResultResponse>(query, new { model.StudentId, model.ExamId, });
        }
    }
}

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
    public class AnswersRepository : BaseRepository<Answer>, IAnswersRepository
    {
        public AnswersRepository(IqraQuranCenterDbContext dbContext) : base(dbContext) { }

        public async Task<int> MakeAllAnswersFalse(Guid questionId)
        {
            string query = $@"UPDATE Answers SET IsCorrect = 0
                              WHERE QuestionId = @questionId";

            return await dbContext.ExecuteAsync(query, new { questionId });
        }

        public async Task<IEnumerable<Answer>> ViewAnswersByQuestionId(Guid questionId)
        {
            string query = $@"SELECT * FROM Answers
                              WHERE QuestionId = @questionId";
            return await dbContext.QueryAsync<Answer>(query, new { questionId });
        }
    }
}

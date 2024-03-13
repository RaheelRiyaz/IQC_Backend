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
    public class NotificationsRepository : BaseRepository<Notification>, INotificationsRepository
    {
        private const string baseQuery = $@"SELECT N.Id,
	                        Title,[Date],GroupId,F.Id as FileId,
	                        FilePath
	                        FROM Notifications N
	                        INNER JOIN Files F
	                        ON F.EntityId = N.Id ";
        public NotificationsRepository(IqraQuranCenterDbContext dbContext) : base(dbContext) { }




        public async Task<IEnumerable<NotificationResponse>> ViewNotifications(FilterNotificationsRequest model)
        {
            var query = new StringBuilder($@"{baseQuery}");

            if (model.GroupId is not null && model.DateTime is null)
            {
                query.Append("WHERE GroupId = @groupId");
            }


            if (model.GroupId is null && model.DateTime is not null)
            {
                query.Append("WHERE Date = @date");
            }

            if (model.GroupId is not null && model.DateTime is not null)
            {
                query.Append("WHERE GroupId = @groupId AND Date = @date  ");
            }

            query.Append($@"  ORDER BY Date DESC OFFSET {model.PageNo - 1} ROWS FETCH NEXT {model.PageSize} ROWS ONLY;");

            return await dbContext.QueryAsync<NotificationResponse>(query.ToString(), new { model.GroupId, Date = model.DateTime });
        }
    }
}

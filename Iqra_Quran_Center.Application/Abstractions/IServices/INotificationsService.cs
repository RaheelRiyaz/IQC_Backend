using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IServices
{
    public interface INotificationsService
    {
        Task<APIResponse<int>> AddNotifiction(NotificationRequest model);
        Task<APIResponse<IEnumerable<NotificationResponse>>> ViewNotifications(FilterNotificationsRequest model);
    }
}

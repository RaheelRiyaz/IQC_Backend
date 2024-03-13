using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Enums;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Services
{
    public class NotificationsService (INotificationsRepository repository,IFileService service) : INotificationsService
    {
        public async Task<APIResponse<int>> AddNotifiction(NotificationRequest model)
        {
            var notification = new Notification
            {
                Date = model.Date,
                GroupId = model.GroupId,
                Title = model.Title
            };

            AppFileRequest appFile = new AppFileRequest
             (
              notification.Id,
              model.File,
              Module.Notification
              );

            var filePath = await service.InsertFileAsync(appFile);

            if (string.IsNullOrEmpty(filePath))
                return APIResponse<int>.ErrorResponse("Cannot save file please try again");

           

            var res = await repository.AddAsync(notification);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Notification has been added successfully");

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<IEnumerable<NotificationResponse>>> ViewNotifications(FilterNotificationsRequest model)
        {
            var notifications = await repository.ViewNotifications(model);

            return APIResponse<IEnumerable<NotificationResponse>>.SuccessResponse(notifications); 
        }
    }
}

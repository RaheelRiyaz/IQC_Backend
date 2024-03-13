using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iqra_Quran_Center.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController (INotificationsService service): ControllerBase
    {
        [HttpPost]
        public async Task<APIResponse<int>> AddNotification([FromForm] NotificationRequest model) =>
            await service.AddNotifiction(model);

        [HttpPost("view-notifications")]
        public async Task<APIResponse<IEnumerable<NotificationResponse>>> ViewNotifications(FilterNotificationsRequest model) =>
            await service.ViewNotifications(model);
    }
}

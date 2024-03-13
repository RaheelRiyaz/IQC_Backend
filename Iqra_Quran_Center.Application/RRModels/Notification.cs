using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
    public record NotificationRequest(IFormFile File,string Title,DateTime Date,Guid? GroupId);
    public class NotificationResponse
    {
        public Guid Id { get; set; }
        public Guid? GroupId { get; set; }
        public string FilePath { get; set; } = null!;
        public DateTime Date { get; set; }
        };

    public record FilterNotificationsRequest(int PageNo,int PageSize,DateTime? DateTime,Guid? GroupId);
}

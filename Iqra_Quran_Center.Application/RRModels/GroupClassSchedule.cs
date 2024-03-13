using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
    public record GroupClassScheduleRequest(Guid SubjectId,Guid TeacherId,Guid GroupId,int Day,TimeOnly From ,TimeOnly To); 
    
    public class GroupClassScheduleResponse
    {
        public Guid ScheduleId { get; set; }
        public Guid GroupId { get; set; }
        public Guid TeacherId { get; set; }
        public string SubjectName { get; set; } = null!;
        public string TeacherEmail { get; set; } = null!;
        public string TeacherName { get; set; } = null!;
        public string GroupName { get; set; } = null!;
        public string StartTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
        public int Day { get; set; }
    };
}

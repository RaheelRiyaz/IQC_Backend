using Iqra_Quran_Center.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
    public class AttendanceRequest
    {
        public DateOnly Date { get; set; }
        public Guid ClassId { get; set; }

        public IEnumerable<StudentAttendance> StudentAttendances { get; set; } = null!;
    }

    public class StudentAttendance
    {
        public Guid StudentId { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
    }

    public record UpdateAttendanceRequest(Guid Id,AttendanceStatus AttendanceStatus);

    public class AttendanceCheckModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public record CheckAttendanceRequest(Guid ClassId,DateTime? Date);

    public record AttendanceResponse
    {
        public Guid Id { get; set; }
        public Guid ClassId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
    }
}

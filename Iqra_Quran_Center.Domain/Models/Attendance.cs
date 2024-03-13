using Iqra_Quran_Center.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class Attendance : BaseEntity
    {
        public DateOnly Date { get; set; }
        public Guid ClassId { get; set; }
        public Guid StudentId { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }


        #region Navigational Properties

        [ForeignKey(nameof(ClassId))]
        public GroupClassSchedule ClassSchedule { get; set; } = null!;


        [ForeignKey(nameof(StudentId))]
        public User User { get; set; } = null!;

        #endregion Navigational Properties
    }
}

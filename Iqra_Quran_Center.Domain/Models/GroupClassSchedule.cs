using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class GroupClassSchedule : BaseEntity
    {
        public Guid GroupId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
        public int Day { get; set; }
        public TimeOnly From { get; set; }
        public TimeOnly To { get; set; }


        #region navigational Properties
        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; } = null!;


        [ForeignKey(nameof(TeacherId))]
        public User User { get; set; } = null!;


        [ForeignKey(nameof(SubjectId))]
        public Subject Subject { get; set; } = null!;
        #endregion navigational Properties
    }
}

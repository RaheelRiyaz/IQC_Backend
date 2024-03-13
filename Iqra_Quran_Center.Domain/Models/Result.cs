using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class Result : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid ExamId { get; set; }
        public int Attempts { get; set; }
        public int MarksObtained { get; set; }
        public bool HasQualified { get; set; }






        #region Navigational Properties
        [ForeignKey(nameof(StudentId))]
        public User User { get; set; } = null!;

        [ForeignKey(nameof(ExamId))]
        public Exam Exam { get; set; } = null!;
        #endregion Navigational Properties
    }
}

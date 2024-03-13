using Iqra_Quran_Center.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class Exam : BaseEntity
    {
        public Guid GroupId { get; set; }
        public Guid SubjectId { get; set; }
        public DateTime ExamDateTime { get; set; }
        public DateTime ExamEndDateTime { get; set; }
        public int TotalNoOfQuestions { get; set; }
        public int TotalMarks { get; set; }
        public int PassingMarks { get; set; }
        public string Title { get; set; } = null!;
        public ExamStatus ExamStatus { get; set; }




        #region Navigational Properties
        [ForeignKey(nameof(SubjectId))]
        public Subject Subject { get; set; } = null!;

        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; } = null!;


        public ICollection<QuestionPaper> Questions { get; set; } = null!;

        #endregion Navigational Properties
    }
}

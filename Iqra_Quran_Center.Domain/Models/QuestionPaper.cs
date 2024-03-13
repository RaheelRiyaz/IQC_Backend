using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class QuestionPaper : BaseEntity
    {
        public Guid ExamId { get; set; }
        public string QuestionTitle { get; set; } = null!;



        #region Navigational Prperties
        [ForeignKey(nameof(ExamId))]
        public Exam Exam { get; set; } = null!;

        public ICollection<Answer> Answers { get; set; } = null!;

        #endregion Navigational Prperties
    }
}

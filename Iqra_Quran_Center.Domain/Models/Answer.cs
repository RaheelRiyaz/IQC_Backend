using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Models
{
    public class Answer : BaseEntity
    {
        public Guid QuestionId { get; set; }
        public string Content { get; set; } = null!;
        public bool IsCorrect { get; set; }


        #region Navigational Properties
        [ForeignKey(nameof(QuestionId))]
        public QuestionPaper QuestionPaper { get; set; } = null!;

        #endregion Navigational Properties
    }
}

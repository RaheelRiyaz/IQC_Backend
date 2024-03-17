using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
    public record ResultFilterRequest
        (
        Guid StudentId,
        Guid ExamId
        );
   public record ResultResponse
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid ExamId { get; set; }
        public Guid GroupId { get; set; }
        public int TotalNoOfQuestions { get; set; }
        public int Attempts { get; set; }
        public int TotalMarks { get; set; }
        public int MarksObtained { get; set; }
        public int PassingMarks { get; set; }
        public bool HasQualified { get; set; }
        public DateTime ExamDateTime { get; set; }
    }
}

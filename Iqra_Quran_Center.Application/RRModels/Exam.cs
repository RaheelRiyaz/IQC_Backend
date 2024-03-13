using Iqra_Quran_Center.Domain.Enums;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
    public record ExamRequest
         (
        Guid GroupId,
        Guid SubjectId,
        DateTime ExamDateTime,
        int TotalNoOfQuestions,
        int TotalMarks,
        int PassingMarks,
        string Title,
        ExamStatus ExamStatus
        );

    public record ExamStatusRequest
        (
        Guid Id,
        ExamStatus ExamStatus,
        DateTime ExamDateTime,
        int TotalNoOfQuestions,
        int TotalMarks,
        int PassingMarks,
        string Title
        );

    public class ExamResponse
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public Guid GroupId { get; set; }
        public DateTime ExamDateTime { get; set; }
        public ExamStatus ExamStatus { get; set; }
        public int TotalNoOfQuestions { get; set; }
        public int TotalMarks { get; set; }
        public int PassingMarks { get; set; }
        public string Title { get; set; } = null!;
        public string Subject { get; set; } = null!;
    }

    public record ExamAttendingRequest(Guid ExamId,IEnumerable<PaperRequest> Answers);

    public class QuestionWithAnswersResponse
    {
        public Guid Examid { get; set; }
        public List<QuestionWithAnswer> QuestionAnswers { get; set; } = null!;
    }

    public class QuestionWithAnswer
    {
        public Guid QuestionId { get; set; }

        public IEnumerable<Answer> Answers { get; set; } = null!;
    }
    public record PaperRequest(Guid QuestionId,Guid AnswerId);
}

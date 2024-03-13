using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
    public record AnswerRequest
        (
        Guid QuestionId,
        string Content,
        bool IsCorrect
        );


    public record AnswerResponse
       (
       Guid QuestionId,
       Guid Id,
       string Content
       );

    public record UpdateAnswerRequest
        (
        Guid QuestionId,
        Guid Id,
        string Content,
        bool IsCorrect
        );
}

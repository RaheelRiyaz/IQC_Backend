using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
    public record QuestionRequest
     (
     Guid ExamId,
     string QuestionTitle
     );


    public record UpdateQuestionRequest
        (
        Guid Id,
        string QuestionTitle
        );

}

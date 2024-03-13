using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
    public record SubjectRequest(string Name);

    public record SubjectsResponse(string Name, bool IsAvailable);
    public record UpdateSubjectsRequest(Guid Id,string Name, bool IsAvailable);

    public record SubjectWithTeacherName(Guid Id,string Subject,string Teacher);
}

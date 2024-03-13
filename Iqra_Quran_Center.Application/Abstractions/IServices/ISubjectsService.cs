using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IServices
{
    public interface ISubjectsService
    {
        Task<APIResponse<IEnumerable<SubjectsResponse>>> ViewSubjects();
        Task<APIResponse<SubjectsResponse>> ViewSubjectById(Guid id);
        Task<APIResponse<SubjectsResponse>> AddSubject(SubjectRequest model);
        Task<APIResponse<int>> UpdateSubject(UpdateSubjectsRequest model);
        Task<APIResponse<IEnumerable<SubjectWithTeacherName>>> ViewSubjectsByGroupId(Guid? groupId);
    }
}

using AutoMapper;
using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Services
{
    public class SubjectsService(ISubjectsRepository repository, IMapper mapper,IContextService contextService) : ISubjectsService
    {
        public async Task<APIResponse<SubjectsResponse>> AddSubject(SubjectRequest model)
        {
            var isExists = await repository.IsExistsAsync(_ => _.Name == model.Name);

            if (isExists)
                return APIResponse<SubjectsResponse>.ErrorResponse("Subject is already added");

            var course = mapper.Map<Subject>(model);

            var res = await repository.AddAsync(course);

            if (res > 0)
                return APIResponse<SubjectsResponse>.SuccessResponse(mapper.Map<SubjectsResponse>(course), "Subject added successfully");

            return APIResponse<SubjectsResponse>.ErrorResponse();
        }

        public async Task<APIResponse<IEnumerable<SubjectsResponse>>> ViewSubjects()
        {
            var courses = await repository.GetAllAsync();

            return APIResponse<IEnumerable<SubjectsResponse>>.SuccessResponse(mapper.Map<IEnumerable<SubjectsResponse>>(courses));

        }

        public async Task<APIResponse<SubjectsResponse>> ViewSubjectById(Guid id)
        {
            var course = await repository.GetByIdAsync(id);

            if (course is null)
                return APIResponse<SubjectsResponse>.ErrorResponse("No such subject found");

            return APIResponse<SubjectsResponse>.SuccessResponse(mapper.Map<SubjectsResponse>(course));
        }

        public async Task<APIResponse<int>> UpdateSubject(UpdateSubjectsRequest model)
        {
            var subject = await repository.GetByIdAsync(model.Id);

            if (subject is null)
                return APIResponse<int>.ErrorResponse("No Such SUbject found");

            subject.UpdatedOn = DateTime.Now;
            subject.Name = model.Name;
            subject.IsAvailable = model.IsAvailable;

            var res = await repository.UpdateAsync(subject);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Subject Updated Successfully");

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<IEnumerable<SubjectWithTeacherName>>> ViewSubjectsByGroupId(Guid? groupId)
        {
            var GROUP_ID = Guid.Parse(Convert.ToString(groupId is null ? contextService.GetGroupId() : groupId)!);

            var subjects = await repository.ViewSubjectsByGroupId(GROUP_ID);

            return APIResponse<IEnumerable<SubjectWithTeacherName>>.SuccessResponse(subjects);
        }
    }
}

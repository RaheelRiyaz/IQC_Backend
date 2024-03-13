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
    public class GroupService(IGroupRepository repository,IMapper mapper,IUserRespository userRespository) : IGroupService
    {
        public async Task<APIResponse<GroupResponse>> AddGroup(GroupRequest model)
        {
            var isExists = await repository.IsExistsAsync(_ => _.Name == model.Name && _.Batch == model.Batch);

            if (isExists)
                return APIResponse<GroupResponse>.ErrorResponse("Group is already present");

            var group = mapper.Map<Group>(model);

            var res = await repository.AddAsync(group);

            if (res > 0)
                return APIResponse<GroupResponse>.SuccessResponse(mapper.Map<GroupResponse>(group), "Group created successfully");


            return APIResponse<GroupResponse>.ErrorResponse();
        }

        public async Task<APIResponse<int>> AssignGroupToStudent(AssignGroupRequst model)
        {
            var student = await userRespository.GetByIdAsync(model.StudentId);

            if(student is null)
                return APIResponse<int>.ErrorResponse("No Student found");

            student.UpdatedOn = DateTime.Now;
            student.GroupId = model.GroupId;

            var res = await userRespository.UpdateAsync(student);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Group has been assigned to student successfully");

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<GroupResponse>> GroupById(Guid id)
        {
            var group = await repository.GetByIdAsync(id);

            if (group is null)
                return APIResponse<GroupResponse>.ErrorResponse("No Such group found");

            return APIResponse<GroupResponse>.SuccessResponse(mapper.Map<GroupResponse>(group));
        }

        public async Task<APIResponse<IEnumerable<GroupResponse>>> Groups()
        {
            var groups = await repository.GetAllAsync();

            return APIResponse<IEnumerable<GroupResponse>>.SuccessResponse(mapper.Map<IEnumerable<GroupResponse>>(groups));
        }

        public async Task<APIResponse<int>> UpdateGroup(UpdateGroupRequest model)
        {
            var group = await repository.GetByIdAsync(model.Id);

            if (group is null)
                return APIResponse<int>.ErrorResponse("No Such group found");

            group.Name = model.Name;
            group.Batch = model.Batch;
            group.IsActive = model.IsActive;
            group.UpdatedOn = DateTime.Now;

            var res = await repository.UpdateAsync(group);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Group has been Updated");

            return APIResponse<int>.ErrorResponse();
        }
    }
}

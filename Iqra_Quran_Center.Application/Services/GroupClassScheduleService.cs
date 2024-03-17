using AutoMapper;
using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;

namespace Iqra_Quran_Center.Application.Services
{
    public class GroupClassScheduleService(IGroupClassScheduleRepository repository, IMapper mapper,IContextService contextService) : IGroupClassScheduleService
    {
        public async Task<APIResponse<GroupClassSchedule>> AddGroupSchedule(GroupClassScheduleRequest model)
        {
            var isExists = await repository.IsExistsAsync(_ =>
                                 _.GroupId == model.GroupId &&
                                 _.Day == model.Day &&
                                 (
                                     (_.From >= model.From && _.From <= model.To) ||
                                     (_.To >= model.From && _.To <= model.To) ||
                                     (_.From <= model.From && _.To >= model.To)
                                 )
                             );

            if (isExists)
                return APIResponse<GroupClassSchedule>.ErrorResponse("There is already a class scheduled for that day for this time please slect other time or day");


            var schedule = mapper.Map<GroupClassSchedule>(model);

            var res = await repository.AddAsync(schedule);

            if (res > 0)
                return APIResponse<GroupClassSchedule>.SuccessResponse(schedule);

            return APIResponse<GroupClassSchedule>.ErrorResponse();
        }

        public async Task<APIResponse<IEnumerable<GroupClassScheduleResponse>>> ViewSchedulesByGroupId(Guid? groupId)
        {
            var GROUP_ID = Guid.Parse(Convert.ToString(groupId is null ? contextService.GetGroupId() : groupId)!);

            var schedules = await repository.ViewScheduleByGroupId(GROUP_ID);

            return APIResponse<IEnumerable<GroupClassScheduleResponse>>.SuccessResponse(schedules);
        }

        public async Task<APIResponse<IEnumerable<GroupClassScheduleResponse>>> ViewSchedulesByTeacherId(Guid? teacherId)
        {
            var Teacher_ID = teacherId is null ? contextService.GetId() : Guid.Parse(Convert.ToString(teacherId)!);

            var schedules = await repository.ViewScheduleByTeacherId(Teacher_ID);

            return APIResponse<IEnumerable<GroupClassScheduleResponse>>.SuccessResponse(schedules);
        }
    }
}

using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IServices
{
    public interface IGroupService
    {
        Task<APIResponse<GroupResponse>> GroupById(Guid id);
        Task<APIResponse<IEnumerable<GroupResponse>>> Groups();
        Task<APIResponse<GroupResponse>> AddGroup(GroupRequest model);
        Task<APIResponse<int>> AssignGroupToStudent(AssignGroupRequst model);
        Task<APIResponse<int>> UpdateGroup(UpdateGroupRequest model);
    }
}

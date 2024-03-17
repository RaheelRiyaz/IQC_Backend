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
    public class GroupFeesService (IGroupFeesRepository repository): IGroupFeesService
    {
        public async Task<APIResponse<int>> CreateGroupFee(GroupFeeRequest model)
        {
            var isFeeAdded = await repository.IsExistsAsync(_ => _.GroupId == model.GroupId);

            if (isFeeAdded)
                return APIResponse<int>.ErrorResponse("Fee already created please update");

            var groupFee = new GroupFees { GroupId = model.GroupId, TotalFee = model.TotalFee };

            var res = await repository.AddAsync(groupFee);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Group fee created successfully");

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<int>> UpdateGroupFee(UpdateGroupFeeRequest model)
        {
            var fee = await repository.GetByIdAsync(model.Id);

            if (fee is null)
                return APIResponse<int>.ErrorResponse("No such group fee found");

            fee.TotalFee = model.TotalFee;

            var res = await repository.UpdateAsync(fee);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Fee has been updated");

            return APIResponse<int>.ErrorResponse();
        }
    }
}

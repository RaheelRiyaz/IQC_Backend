using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iqra_Quran_Center.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupFeesController (IGroupFeesService service): ControllerBase
    {
        [HttpPost]
        public async Task<APIResponse<int>> CreateGroupFee(GroupFeeRequest model) =>
            await service.CreateGroupFee(model);


        [HttpPut]
        public async Task<APIResponse<int>> UpdateGroupFee(UpdateGroupFeeRequest model) =>
            await service.UpdateGroupFee(model);
    }
}

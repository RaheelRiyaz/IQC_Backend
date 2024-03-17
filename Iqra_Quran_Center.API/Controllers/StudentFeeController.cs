using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Microsoft.AspNetCore.Mvc;

namespace Iqra_Quran_Center.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentFeeController (IStudentFeesService service): ControllerBase
    {
        [HttpPost]
        public async Task<APIResponse<int>> SubmitFee(StudentFeeHistoryRequest model) =>
            await service.SubmitFee(model);


        [HttpPost("check-fee-history")]
        public async Task<APIResponse<IEnumerable<StudentFeeHistoryResponse>>> ViewStudentFeeHistory(StudentFeeHistoryFilterRequest model) =>
            await service.ViewStudentFeeHistory(model);


        [HttpPut]
        public async Task<APIResponse<int>> UpdateStudentFeeHistory(UpdateStudentFeeRequest model) =>
            await service.UpdateStudentFeeHistory(model);
    }
}

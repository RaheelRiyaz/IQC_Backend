using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iqra_Quran_Center.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController (IResultsService service): ControllerBase
    {
        [HttpPost("view")]
        public async Task<APIResponse<ResultResponse>> CheckResult(ResultFilterRequest model) =>
            await service.CheckResult(model);
    }
}

using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Services
{
    public class ResultsService (IResultsRepository repository): IResultsService
    {
        public async Task<APIResponse<ResultResponse>> CheckResult(ResultFilterRequest model)
        {
            var result = await repository.ViewResult(model);

            if (result is null)
                return APIResponse<ResultResponse>.ErrorResponse("No Such Result Found");

            return APIResponse<ResultResponse>.SuccessResponse(result);
        }
    }
}

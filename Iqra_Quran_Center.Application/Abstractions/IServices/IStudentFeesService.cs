using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;

namespace Iqra_Quran_Center.Application.Abstractions.IServices
{
    public interface IStudentFeesService
    {
        Task<APIResponse<int>> SubmitFee(StudentFeeHistoryRequest model);
        Task<APIResponse<IEnumerable<StudentFeeHistoryResponse>>> ViewStudentFeeHistory(StudentFeeHistoryFilterRequest model);
        Task<APIResponse<int>> UpdateStudentFeeHistory(UpdateStudentFeeRequest model);
    }
}

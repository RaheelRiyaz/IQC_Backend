using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;

namespace Iqra_Quran_Center.Application.Services
{
    public class StudentFeesService (IStudentFeesHistoryRepository repository): IStudentFeesService
    {
        public async Task<APIResponse<int>> SubmitFee(StudentFeeHistoryRequest model)
        {
            var isFeeSubmitted = await repository.IsExistsAsync(_ => _.StudentId == model.StudentId && _.Date == model.Date);

            if (isFeeSubmitted)
                return APIResponse<int>.ErrorResponse("Fee Already submiited for this month");

            var fee = new StudentFeeHistory
            {
                Date = model.Date,
                PaymentMethod = model.PaymentMethod,
                StudentId = model.StudentId,
                TotalFeeSubmitted = model.TotalFeeSubmitted
            };

            var res = await repository.AddAsync(fee);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Fee Submitted Successfully");

            return APIResponse<int>.ErrorResponse();
        }


        public async Task<APIResponse<int>> UpdateStudentFeeHistory(UpdateStudentFeeRequest model)
        {
            var history = await repository.GetByIdAsync(model.Id);

            if (history is null)
                return APIResponse<int>.ErrorResponse("No such Fee history found");

            history.Date = model.Date;
            history.TotalFeeSubmitted = model.TotalFeeSubmitted;
            history.PaymentMethod = model.PaymentMethod;
            history.UpdatedOn = DateTime.Now;

            var res = await repository.UpdateAsync(history);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Updated successfully");

            return APIResponse<int>.ErrorResponse();
        }


        public async Task<APIResponse<IEnumerable<StudentFeeHistoryResponse>>> ViewStudentFeeHistory(StudentFeeHistoryFilterRequest model)
        {
            var history = await repository.ViewStudentFeeHistory(model);

            return APIResponse<IEnumerable<StudentFeeHistoryResponse>>.SuccessResponse(history);
        }
    }
}

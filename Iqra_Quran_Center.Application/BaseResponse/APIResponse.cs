using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.BaseResponse
{
    public class APIResponse<T>
    {
        public string Message { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T? Result { get; set; }



        public static APIResponse<T> SuccessResponse(T result,string message = "Success", HttpStatusCode statusCode = HttpStatusCode.OK) =>
            new APIResponse<T> { IsSuccess = true, Message = message, StatusCode = statusCode, Result = result };



        public static APIResponse<T> ErrorResponse(string message = "Error", HttpStatusCode statusCode = HttpStatusCode.InternalServerError) =>
            new APIResponse<T> { IsSuccess = false, Message = message, StatusCode = statusCode };
    }
}

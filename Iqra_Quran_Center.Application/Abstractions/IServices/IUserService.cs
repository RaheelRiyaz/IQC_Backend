using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Abstractions.IServices
{
    public interface IUserService 
    {
        Task<APIResponse<User>> UserSignup(UserRequest model);
        Task<APIResponse<int>> StudentSignup(StudentSignupRequest model);
        Task<APIResponse<IEnumerable<User>>> Faculty();
        Task<APIResponse<LoginResponse>> Login(LoginRequest model);
    }
}

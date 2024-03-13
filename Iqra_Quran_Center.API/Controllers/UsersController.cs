using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iqra_Quran_Center.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService service) : ControllerBase
    {
        [HttpPost("signup")]
        public async Task<APIResponse<User>> Signup(UserRequest model) =>
            await service.UserSignup(model);



        [HttpGet("faculty")]
        public async Task<APIResponse<IEnumerable<User>>> Faculty() =>
            await service.Faculty();



        [HttpPost("student-signup")]
        public async Task<APIResponse<int>> StudentSignup(StudentSignupRequest model) =>
            await service.StudentSignup(model);



        [HttpPost("login")]
        public async Task<APIResponse<LoginResponse>> Login(LoginRequest model) =>
            await service.Login(model);
    }
}

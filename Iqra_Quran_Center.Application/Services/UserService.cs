using AutoMapper;
using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Application.Utilis;
using Iqra_Quran_Center.Domain.Enums;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Services
{
    public class UserService(IUserRespository respository,IMapper mapper,ITokenService tokenService) : IUserService
    {
        public async Task<APIResponse<IEnumerable<User>>> Faculty()
        {
            var faculty = await respository.FilterAsync(_ => _.UserRole == UserRole.Teacher);

            return APIResponse<IEnumerable<User>>.SuccessResponse(faculty);
        }

        public async Task<APIResponse<LoginResponse>> Login(LoginRequest model)
        {
            var user = await respository.FirstOrDefaultAsync(_ => _.Email == model.Email);

            if (user is null)
                return APIResponse<LoginResponse>.ErrorResponse("Invalid Crdentials");


            if (!AppEncryption.ComparePassword(user.Password, user.Salt, model.Password))
                return APIResponse<LoginResponse>.ErrorResponse("Invalid Crdentials");


            var loginResponse = new LoginResponse(tokenService.GenerateToken(user));

            return APIResponse<LoginResponse>.SuccessResponse(loginResponse, "Logged in successfully");
        }

        public async Task<APIResponse<int>> StudentSignup(StudentSignupRequest model)
        {
            var isEmailTaken = await respository.IsExistsAsync(_ => _.Email == model.Email);

            var student = new User
            {
                Email = model.Email,
                Salt = AppEncryption.GenerateSalt(),
                UserRole = UserRole.Student,
                GroupId = model.GroupId,
                Name = model.Name
            };

            student.Password = AppEncryption.GenerateHashedPassword(student.Salt,model.Password);

            var res = await respository.AddAsync(student);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Student Created Successfully");

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<User>> UserSignup(UserRequest model)
        {
            var isEmailTaken = await respository.IsExistsAsync(_ => _.Email == model.Email);

            if (isEmailTaken)
                return APIResponse<User>.ErrorResponse("Email is already taken");

            var user = mapper.Map<User>(model);

            user.Salt = AppEncryption.GenerateSalt();
            user.Password = AppEncryption.GenerateHashedPassword(user.Salt, user.Password);


            var res = await respository.AddAsync(user);

            if (res > 0)
                return APIResponse<User>.SuccessResponse(user, $@"{(user.UserRole == UserRole.Admin ? nameof(UserRole.Admin) : user.UserRole == UserRole.Teacher ? nameof(UserRole.Teacher) : string.Empty)} Created Successfully");

            return APIResponse<User>.ErrorResponse();
        }
    }
}

using Iqra_Quran_Center.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.RRModels
{
    public record UserRequest(string Name, string Email,string Password,UserRole UserRole);
    public record StudentSignupRequest(string Name,string Email,string Password,Guid? GroupId);
    public record LoginRequest(string Email, string Password);
    public record LoginResponse(string Token);
    public record AssignGroupRequst (Guid StudentId,Guid GroupId);
}

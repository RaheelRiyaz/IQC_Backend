using Iqra_Quran_Center.Application.Abstractions.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Infratstructure.Services
{
    public class ContextService (IHttpContextAccessor httpContextAccessor) : IContextService
    {
        public Guid? GetGroupId()
        {
            var groupId = httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(_ => _.Type == "GroupId")?.Value;

            return groupId is not null ? Guid.Parse(groupId) : null;
        }

        public Guid GetId()
        {
            var userId = httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(_ => _.Type == "Id")?.Value;

            return userId is not null ? Guid.Parse(userId) : Guid.Empty;
        }
    }
}

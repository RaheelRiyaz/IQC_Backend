using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Infratstructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Infratstructure.DI_Container
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITokenService>(new TokenService(configuration));
            services.AddSingleton<IContextService, ContextService>();
            return services;
        }
    }
}

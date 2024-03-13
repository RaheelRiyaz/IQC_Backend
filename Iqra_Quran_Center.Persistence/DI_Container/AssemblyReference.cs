using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Persistence.Data;
using Iqra_Quran_Center.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Persistence.DI_Container
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddPersisitenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContextPool<IqraQuranCenterDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(nameof(IqraQuranCenterDbContext)));
            });


            services.AddScoped<IUserRespository, AdminRepository>();
            services.AddScoped<ISubjectsRepository, SubjectsRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupClassScheduleRepository, GroupClassScheduleRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IExamsRepository, ExamsRepository>();
            services.AddScoped<IQuestionsRepository, QuestionsRepository>();
            services.AddScoped<IAnswersRepository, AnswersRepository>();
            services.AddScoped<IAppFilesRepository, AppFilesRepository>();
            services.AddScoped<INotificationsRepository, NotificationsRepository>();
            services.AddScoped<IResultsRepository, ResultsRepository>();
            return services;
        }
    }
}

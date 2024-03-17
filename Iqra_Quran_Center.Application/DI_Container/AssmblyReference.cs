using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.DI_Container
{
    public static class AssmblyReference
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,string webrootPath)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISubjectsService, SubjectsService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupClassScheduleService, GroupClassScheduleService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IExamsService, ExamsService>();
            services.AddScoped<IQuestionsService, QuestionsService>();
            services.AddScoped<IAnswersService, AnswersService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<INotificationsService, NotificationsService>();
            services.AddScoped<IResultsService, ResultsService>();
            services.AddScoped<IGroupFeesService, GroupFeesService>();
            services.AddScoped<IStudentFeesService, StudentFeesService>();
            services.AddSingleton<IStorageService>(new StorageService(webrootPath));
            return services;
        }
    }
}

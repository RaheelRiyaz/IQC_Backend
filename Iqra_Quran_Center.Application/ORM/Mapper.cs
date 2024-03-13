using AutoMapper;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.ORM
{
    public class AdminMapper : Profile
    {
        public AdminMapper()
        {
            CreateMap<UserRequest, User>();
        }
    }


    public class SubjectsMapper : Profile
    {
        public SubjectsMapper()
        {
            CreateMap<SubjectRequest, Subject>();
            CreateMap<Subject, SubjectsResponse>();
        }
    }


    public class GroupMapper : Profile
    {
        public GroupMapper()
        {
            CreateMap<GroupRequest, Group>();
            CreateMap<Group, GroupResponse>();
        }
    }


    public class GroupClassScheduleMapper : Profile
    {
        public GroupClassScheduleMapper()
        {
            CreateMap<GroupClassScheduleRequest, GroupClassSchedule>();
        }
    }



    public class ExamMapper : Profile
    {
        public ExamMapper()
        {
            CreateMap<ExamRequest, Exam>();
        }
    }
}

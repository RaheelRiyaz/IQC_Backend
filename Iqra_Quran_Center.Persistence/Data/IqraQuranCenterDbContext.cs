using Iqra_Quran_Center.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Persistence.Data
{
    public class IqraQuranCenterDbContext : DbContext
    {
        public IqraQuranCenterDbContext(DbContextOptions options) : base(options)
        {
        }


        #region Database Tables
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<GroupClassSchedule> GroupClassSchedules { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<Exam> Exams { get; set; } = null!;
        public DbSet<QuestionPaper> Questions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<AppFile> Files { get; set; } = null!;
        public DbSet<Result> Results { get; set; } = null!;
        public DbSet<GroupFees> GroupFees { get; set; } = null!;
        public DbSet<StudentFeeHistory> StudentFeeHistory { get; set; } = null!;
        #endregion Database Tables

    }
}

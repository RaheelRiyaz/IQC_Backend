using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Domain.Enums
{
    public enum UserRole : byte
    {
        Admin = 1,
        Teacher = 2,
        Student = 3
    }



    public enum AttendanceStatus : byte
    {
        Present = 1,
        Absent = 2,
        Leave = 3
    }


    public enum ExamStatus : byte
    {
        Conducted = 1,
        ToBeConducted = 2,
        PostPoned = 3,
    }


    public enum Module : byte
    {
        Notification = 1,
        Profile = 2
    }


    public enum PaymentMethod : byte
    {
        Cash = 1,
        Online = 2
    } 
}

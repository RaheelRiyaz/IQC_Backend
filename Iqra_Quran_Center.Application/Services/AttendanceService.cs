using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Services
{
    public class AttendanceService (IAttendanceRepository repository) : IAttendanceService
    {
        public async Task<APIResponse<int>> Attendance(AttendanceRequest model)
        {
            var isExists = await repository.IsExistsAsync(_=>_.ClassId == model.ClassId && _.Date == model.Date);

            if (isExists)
                return APIResponse<int>.ErrorResponse("Attendance has been already updated for today's class");

            var dbStudents = await repository.CheckNoOfStudents(model.ClassId);

            if (dbStudents.Count() > model.StudentAttendances.Count())
                return APIResponse<int>.ErrorResponse($"{dbStudents.Count() - model.StudentAttendances.Count()} student attendances are missing");


            foreach (var student in dbStudents)
            {
                var exists = model.StudentAttendances.Any(_=>_.StudentId == student.Id);

                if (!exists)
                    return APIResponse<int>.ErrorResponse($"{student.Name}'s attendance is missing");
            }

            var attendences = new List<Attendance>();

            foreach (var item in model.StudentAttendances)
            {
                attendences.Add(new Attendance
                {
                    ClassId = model.ClassId,
                    AttendanceStatus = item.AttendanceStatus,
                    StudentId = item.StudentId,
                    Date = model.Date
                });
            }


            var res = await repository.AddRangeAsync(attendences);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Attendance has been saved");

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<int>> UpdateStudentAttendance(UpdateAttendanceRequest model)
        {
            var attendance = await repository.GetByIdAsync(model.Id);

            if (attendance is null)
                return APIResponse<int>.ErrorResponse("No attendance found");

            attendance.AttendanceStatus = model.AttendanceStatus;

            var res = await repository.UpdateAsync(attendance);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Attendance status changed");


            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<IEnumerable<AttendanceResponse>>> ViewAttendances(CheckAttendanceRequest model)
        {
            var attendances = await repository.ViewAttendance(model);

            return APIResponse<IEnumerable<AttendanceResponse>>.SuccessResponse(attendances);
        }
    }
}

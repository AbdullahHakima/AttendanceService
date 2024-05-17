using Data.Entities;

namespace Service.Interfaces;

public interface IAttendanceRecordService
{
    Task InitializeAttendanceRecord(AttendanceRecord attendanceRecord);
    Task<AttendanceRecord> GetAttendanceRecord(Guid studentId, Guid courseId);
    Task UpdateStudentAttendanceAsync(Guid sessionId);

}

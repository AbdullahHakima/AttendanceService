using Data.Entities;

namespace Service.Interfaces;

public interface IAttendanceSessionService
{
    Task<AttendanceSession?> GetAttendanceSessionAsync(Guid sessionId);
    Task<List<AttendanceSession>> GetAttendanceSessionsAsync(Guid courseId);
    Task<AttendanceSession> AddAttendanceSessionAsync(AttendanceSession attendanceSession);
    Task DeleteAttendanceSessionAsync(AttendanceSession attendanceSession);
    Task UpdateAttendanceSessionAsync(AttendanceSession attendanceSession);
    Task HandleEndedSessionsAsync();
}

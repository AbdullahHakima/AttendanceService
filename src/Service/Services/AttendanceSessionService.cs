using Data.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service.Services;

public class AttendanceSessionService : IAttendanceSessionService
{
    #region Fields
    private readonly IAttendanceSessionRepository _attendanceSessionRepository;
    private readonly IAttendanceRecordService _attendanceRecordService;
    #endregion

    #region Constructors

    public AttendanceSessionService(IAttendanceSessionRepository attendanceSessionRepository, IAttendanceRecordService attendanceRecordService)
    {
        _attendanceSessionRepository = attendanceSessionRepository;
        _attendanceRecordService = attendanceRecordService;
    }
    #endregion
    #region Methods
    public async Task<AttendanceSession> AddAttendanceSessionAsync(AttendanceSession attendanceSession)
    {
        return await _attendanceSessionRepository.AddAsync(attendanceSession);
    }

    public async Task DeleteAttendanceSessionAsync(AttendanceSession attendanceSession)
    {
        await _attendanceSessionRepository.DeleteAsync(attendanceSession);
    }

    public async Task<AttendanceSession?> GetAttendanceSessionAsync(Guid sessionId)
    {
        string[] includes = { "instructor", "Location" };
        return await _attendanceSessionRepository.FindAsync(s => s.Id == sessionId, includes);
    }

    public async Task<List<AttendanceSession>> GetAttendanceSessionsAsync(Guid courseId)
    {
        return await _attendanceSessionRepository.GetTableNoTracking()
                                                 .Include(s => s.instructor)
                                                 .Include(sl => sl.Location)
                                                 .ToListAsync();
    }

    public async Task HandleEndedSessionsAsync()
    {
        var endedSessions = await _attendanceSessionRepository.GetEndedSessionsAsync();
        foreach (var Session in endedSessions)
        {
            await _attendanceRecordService.UpdateStudentAttendanceAsync(Session.Id);
        }
    }

    public async Task UpdateAttendanceSessionAsync(AttendanceSession attendanceSession)
    {
        await _attendanceSessionRepository.UpdateAsync(attendanceSession);

    }
    #endregion

}

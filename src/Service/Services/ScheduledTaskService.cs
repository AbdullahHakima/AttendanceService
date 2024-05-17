using Service.Interfaces;

namespace Service.Services;

public class ScheduledTaskService : IScheduledTaskService
{
    #region Fields
    private readonly IAttendanceSessionService _attendanceSessionService;
    #endregion
    #region Constructors

    public ScheduledTaskService(IAttendanceSessionService attendanceSessionService)
    {
        _attendanceSessionService = attendanceSessionService;
    }

    #endregion
    #region Methods

    public async Task UpdateAttendanceForEndedSessions()
    {
        await _attendanceSessionService.HandleEndedSessionsAsync();

    }
    #endregion

}

using Data.Entities;
using Infrastructure.Bases;

namespace Infrastructure.Interfaces;

public interface IAttendanceSessionRepository : IGenericRepositoryAsync<AttendanceSession>
{
    Task<List<AttendanceSession>> GetEndedSessionsAsync();
}

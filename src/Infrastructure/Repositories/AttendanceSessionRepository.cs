using Data.Entities;
using Infrastructure.Bases;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AttendanceSessionRepository : GenericRepositoryAsync<AttendanceSession>, IAttendanceSessionRepository
{
    private readonly DbSet<AttendanceSession> _attendanceSessions;

    public AttendanceSessionRepository(ExamServiceDbContext context) : base(context)
    {
        _attendanceSessions = context.Set<AttendanceSession>();
    }

    public async Task<List<AttendanceSession>> GetEndedSessionsAsync()
    {
        return await _attendanceSessions.Where(s => s.EndAt.ToLocalTime() < DateTime.Now).ToListAsync();
    }
}

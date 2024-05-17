using Data.Entities;
using Infrastructure.Bases;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AttendanceRecordRepository : GenericRepositoryAsync<AttendanceRecord>, IAttendanceRecordRepository
{
    private readonly DbSet<AttendanceRecord> _attendanceRecordRepository;
    public AttendanceRecordRepository(ExamServiceDbContext context) : base(context)
    {
        _attendanceRecordRepository = context.Set<AttendanceRecord>();

    }
}

using Data.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service.Services;

public class AttendanceRecordService : IAttendanceRecordService
{
    #region Fields
    private readonly IAttendanceRecordRepository _attendanceRecordRepository;
    private readonly IDistanceSolverService _distanceSolverService;
    private readonly IAttendanceSessionRepository _attendanceSessionRepository;
    #endregion

    #region Constructor
    public AttendanceRecordService(IAttendanceRecordRepository attendanceRecordRepository, IDistanceSolverService distanceSolverService, IAttendanceSessionRepository attendanceSessionRepository)
    {
        _attendanceRecordRepository = attendanceRecordRepository;
        _distanceSolverService = distanceSolverService;
        _attendanceSessionRepository = attendanceSessionRepository;
    }
    #endregion

    #region Methods
    public Task<AttendanceRecord> GetAttendanceRecord(Guid studentId, Guid courseId)
    {
        throw new NotImplementedException();
    }

    public async Task InitializeAttendanceRecord(AttendanceRecord attendanceRecord)
    {

        await _attendanceRecordRepository.AddAsync(attendanceRecord);
    }

    public async Task UpdateStudentAttendanceAsync(Guid sessionId)
    {
        double instructorLatitude;
        double instructorLongitude;
        var session = await _attendanceSessionRepository.FindAsync(s => s.Id == sessionId, new[] { "Location" });
        if (session.IsDynamic)
        {
            instructorLatitude = (double)session.Latitude;
            instructorLongitude = (double)session.Longitude;
        }
        else
        {
            instructorLatitude = session.Location.Latitude;
            instructorLongitude = session.Location.Longitude;
        }
        var records = _attendanceRecordRepository.GetTableNoTracking()
                                    .Include(x => x.Student)
                                    .Where(r => (r.AttendanceSessionId == sessionId && r.Status == AttendanceStatus.Pending))
                                    .ToList();
        foreach (var record in records)
        {
            var studentDistance = _distanceSolverService.DistanceCalculator(record.StudentLatitude, record.StudentLongitude, instructorLatitude, instructorLongitude);
            if (_distanceSolverService.InAcceptableRange(studentDistance, session.Radius) && record.SubmissionTimestamp <= session.EndAt)
            {
                record.Status = AttendanceStatus.Present;
                await _attendanceRecordRepository.UpdateAsync(record);
            }
            else if (_distanceSolverService.InAcceptableRange(studentDistance, session.Radius) && record.SubmissionTimestamp > session.EndAt)
            {
                record.Status = AttendanceStatus.Late;
                await _attendanceRecordRepository.UpdateAsync(record);
            }
            else
            {
                record.Status = AttendanceStatus.Absent;
                await _attendanceRecordRepository.UpdateAsync(record);
            }

        }

    }
    #endregion


}

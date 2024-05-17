using Core.Bases;
using Data.Helpers.Dtos.AttendanceRecords;
using MediatR;

namespace Core.Features.AttendanceRecords.Commands.Models.Add;

public class MarkAttendanceCommandModel : IRequest<Response<string>>
{
    public Guid sessionId { get; set; }
    public Guid studentId { get; set; }
    public AddAttendnaceRecordDto recordDto { get; set; }
}

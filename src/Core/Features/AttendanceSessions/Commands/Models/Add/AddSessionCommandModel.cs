using Core.Bases;
using Data.Helpers.Dtos.AttedanceSessions;
using MediatR;

namespace Core.Features.AttendanceSessions.Commands.Models.Add;

public class AddSessionCommandModel : IRequest<Response<ViewSessionDto>>
{
    public Guid instructorId { get; set; }
    public Guid courseId { get; set; }
    public AddSessionDto sessionDto { get; set; }
}

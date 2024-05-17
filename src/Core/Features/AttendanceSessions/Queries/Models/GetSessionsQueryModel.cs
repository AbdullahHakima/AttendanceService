using Core.Bases;
using Core.Features.AttendanceSessions.Queries.Responses;
using MediatR;

namespace Core.Features.AttendanceSessions.Queries.Models;

public class GetSessionsQueryModel : IRequest<Response<GetSessionsQueryResponse>>
{
    public Guid courseId { get; set; }
}

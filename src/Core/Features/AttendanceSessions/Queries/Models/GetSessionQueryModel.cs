using Core.Bases;
using Core.Features.AttendanceSessions.Queries.Responses;
using MediatR;

namespace Core.Features.AttendanceSessions.Queries.Models;

public class GetSessionQueryModel : IRequest<Response<GetSessionQueryResponse>>
{
    public Guid sessionId { get; set; }
}

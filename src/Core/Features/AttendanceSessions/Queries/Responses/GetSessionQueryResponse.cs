using Data.Helpers.Dtos.AttedanceSessions;

namespace Core.Features.AttendanceSessions.Queries.Responses;

public class GetSessionQueryResponse
{
    public ViewSessionDto Session { get; set; }
}

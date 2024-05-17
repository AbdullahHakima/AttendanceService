using Data.Helpers.Dtos.AttedanceSessions;

namespace Core.Features.AttendanceSessions.Queries.Responses;

public class GetSessionsQueryResponse
{
    public List<ViewSessionDto> sessions { get; set; }
}

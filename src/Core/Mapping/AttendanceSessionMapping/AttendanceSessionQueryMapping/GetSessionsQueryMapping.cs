using Core.Features.AttendanceSessions.Queries.Responses;
using Data.Entities;
using Data.Helpers.Dtos.AttedanceSessions;

namespace Core.Mapping.AttendanceSessionMapping;

public partial class AttendanceSessionProfile
{
    public void GetSessionsQueryMapping()
    {
        CreateMap<List<AttendanceSession>, GetSessionsQueryResponse>()
            .ForMember(dest => dest.sessions, opt => opt.MapFrom(src => src.Select(s => new ViewSessionDto
            {
                Radius = s.Radius,
                EndDate = s.EndAt,
                StartDate = s.StartAt,
                InstructorName = s.instructor.DisplayName,
                Latitude = s.IsDynamic ? s.Latitude : s.Location.Latitude,
                Longitude = s.IsDynamic ? s.Longitude : s.Location.Longitude
            })));
    }
}

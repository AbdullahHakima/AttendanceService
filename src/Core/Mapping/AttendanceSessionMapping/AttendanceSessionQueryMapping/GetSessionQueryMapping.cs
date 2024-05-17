using Core.Features.AttendanceSessions.Queries.Responses;
using Data.Entities;
using Data.Helpers.Dtos.AttedanceSessions;

namespace Core.Mapping.AttendanceSessionMapping;
public partial class AttendanceSessionProfile
{
    public void GetSessionQueryMapping()
    {
        CreateMap<AttendanceSession, GetSessionQueryResponse>()
            .ForMember(dest => dest.Session, opt => opt.MapFrom(src =>
                                                                    new ViewSessionDto
                                                                    {
                                                                        Radius = src.Radius,
                                                                        EndDate = src.EndAt,
                                                                        StartDate = src.StartAt,
                                                                        InstructorName = src.instructor.DisplayName,
                                                                        Latitude = src.IsDynamic ? src.Latitude : src.Location.Latitude,
                                                                        Longitude = src.IsDynamic ? src.Longitude : src.Location.Longitude
                                                                    }));

    }
}


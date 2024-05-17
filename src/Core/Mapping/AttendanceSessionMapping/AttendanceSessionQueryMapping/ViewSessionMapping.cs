using Data.Entities;
using Data.Helpers.Dtos.AttedanceSessions;

namespace Core.Mapping.AttendanceSessionMapping;

public partial class AttendanceSessionProfile
{
    public void ViewSessionMapping()
    {
        CreateMap<AttendanceSession, ViewSessionDto>()
            .ForMember(dest => dest.Radius, opt => opt.MapFrom(src => src.Radius))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartAt.ToLocalTime()))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndAt.ToLocalTime()))
            .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.instructor.DisplayName))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.IsDynamic ? src.Latitude : src.Location.Latitude))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.IsDynamic ? src.Longitude : src.Location.Longitude));
    }

}


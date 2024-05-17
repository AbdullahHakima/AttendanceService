using Core.Features.AttendanceSessions.Commands.Models.Add;
using Data.Entities;

namespace Core.Mapping.AttendanceSessionMapping;
public partial class AttendanceSessionProfile
{
    public void AddSessionMapping()
    {
        CreateMap<AddSessionCommandModel, AttendanceSession>()
            .ForMember(dest => dest.StartAt, opt => opt.MapFrom(src => DateTime.Now.ToUniversalTime())) // Adjust to consider time zone if necessary
            .ForMember(dest => dest.EndAt, opt => opt.MapFrom(src => DateTime.Now.AddMinutes(src.sessionDto.Durantion).ToUniversalTime())) // Assuming 'Durantion' is a typo and should be 'Duration'
            .ForMember(dest => dest.Radius, opt => opt.MapFrom(src => src.sessionDto.Radius))
            .ForMember(dest => dest.IsDynamic, opt => opt.MapFrom(src => src.sessionDto.IsDynamic))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.sessionDto.IsDynamic ? src.sessionDto.Latitude : null))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.sessionDto.IsDynamic ? src.sessionDto.Longitude : null))
            .ForMember(dest => dest.Location, opt => opt.Condition(src => !src.sessionDto.IsDynamic)) // Only map Location if IsDynamic is false
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src =>
                src.sessionDto.IsDynamic ?
                    null : // Ignore Location if dynamic
                    new Location { Id = src.sessionDto.PredefinedLocationId.Value } // Use the predefined location if not dynamic
            ))
            .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.instructorId))
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.courseId));


    }
}


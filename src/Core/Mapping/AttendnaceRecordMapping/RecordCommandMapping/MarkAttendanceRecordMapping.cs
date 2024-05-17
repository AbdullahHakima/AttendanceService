using Core.Features.AttendanceRecords.Commands.Models.Add;
using Data.Entities;

namespace Core.Mapping.AttendnaceRecordMapping;

public partial class AttendnaceRecordProfile
{
    public void MarkAttendanceRecordMapping()
    {
        CreateMap<MarkAttendanceCommandModel, AttendanceRecord>()
            .ForMember(dest => dest.AttendanceSessionId, opt => opt.MapFrom(src => src.sessionId))
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.studentId))
            .ForMember(dest => dest.StudentLatitude, opt => opt.MapFrom(src => src.recordDto.StudentLatitude))
            .ForMember(dest => dest.StudentLongitude, opt => opt.MapFrom(src => src.recordDto.StudentLongitude))
            .ForMember(dest => dest.SubmissionTimestamp, opt => opt.MapFrom(src => src.recordDto.SubmissionTimestamp.ToUniversalTime()))
            .ForMember(dest => dest.Justification, opt => opt.MapFrom(src => src.recordDto.Justification))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => AttendanceStatus.Pending));

    }
}


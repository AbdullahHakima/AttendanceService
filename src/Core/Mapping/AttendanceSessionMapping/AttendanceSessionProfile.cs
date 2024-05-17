using AutoMapper;

namespace Core.Mapping.AttendanceSessionMapping;

public partial class AttendanceSessionProfile : Profile
{
    public AttendanceSessionProfile()
    {
        AddSessionMapping();
        ViewSessionMapping();
        GetSessionQueryMapping();
        GetSessionsQueryMapping();
    }
}

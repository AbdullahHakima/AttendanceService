using Core.Features.Students.Queries.Response;
using Data.Entities;

namespace Core.Mapping.StudentMapping;

public partial class StudentProfile
{
    public void GetStudentQueryMapping()
    {
        CreateMap<Student, GetStudentByIdQueryResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName));
    }
}

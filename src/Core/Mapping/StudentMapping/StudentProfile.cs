using AutoMapper;

namespace Core.Mapping.StudentMapping;

public partial class StudentProfile : Profile
{
    public StudentProfile()
    {
        GetStudentQueryMapping();
    }
}

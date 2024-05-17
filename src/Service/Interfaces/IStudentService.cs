using Data.Entities;

namespace Service.Interfaces;

public interface IStudentService
{
    Task<Student> GetStudent(Guid id);
}

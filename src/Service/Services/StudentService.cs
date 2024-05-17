using Data.Entities;
using Infrastructure.Interfaces;
using Service.Interfaces;

namespace Service.Services;

public class StudentService : IStudentService
{
    #region Fields
    private readonly IStudentRepository _studentRepository;
    #endregion

    #region Constructors
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    #endregion

    #region Methods 
    public async Task<Student?> GetStudent(Guid id)
    {
        return await _studentRepository.FindAsync(x => x.Id == id);
    }
    #endregion
}

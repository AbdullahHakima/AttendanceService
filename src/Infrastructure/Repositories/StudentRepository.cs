using Data.Entities;
using Infrastructure.Bases;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
{
    private readonly DbSet<Student> _studentRepository;
    public StudentRepository(ExamServiceDbContext context) : base(context)
    {

        _studentRepository = context.Set<Student>();
    }
}

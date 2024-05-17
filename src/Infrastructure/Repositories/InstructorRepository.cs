using Data.Entities;
using Infrastructure.Bases;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
{
    private readonly DbSet<Instructor> _instructorRepository;
    public InstructorRepository(ExamServiceDbContext context) : base(context)
    {
        _instructorRepository = context.Set<Instructor>();
    }
}

using Infrastructure.Bases;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ModuleInfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient<IInstructorRepository, InstructorRepository>();
        services.AddTransient<ILocationRepository, LocationRepository>();
        services.AddTransient<IAttendanceSessionRepository, AttendanceSessionRepository>();
        services.AddTransient<IAttendanceRecordRepository, AttendanceRecordRepository>();
        return services;
    }
}

using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Interfaces;
using Service.Services;

namespace Service;

public static class ModuleServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services, IHostApplicationBuilder builder)
    {
        services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<ILocationService, LocationService>();
        services.AddTransient<IAttendanceSessionService, AttendanceSessionService>();
        services.AddTransient<IDistanceSolverService, DistanceSolverService>();
        services.AddTransient<IScheduledTaskService, ScheduledTaskService>();
        services.AddTransient<IAttendanceRecordService, AttendanceRecordService>();
        services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(postgreSqlOptions =>
                {
                    // Setup the connection factory
                    postgreSqlOptions.UseNpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
                }, new PostgreSqlStorageOptions
                {
                    SchemaName = "ScheduledTasks"
                }));

        services.AddHangfireServer();
        // Inject dependencies directly into the method
        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            var recurringJobManager = serviceProvider.GetRequiredService<IRecurringJobManager>();

            // Schedule the job
            recurringJobManager.AddOrUpdate(
                "UpdateStudentAttendance",
                () => serviceProvider.GetRequiredService<IScheduledTaskService>().UpdateAttendanceForEndedSessions(),
                Cron.Minutely());  // Cron expression for every minute
        }

        return services;
    }
}

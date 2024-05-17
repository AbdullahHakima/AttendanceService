using Core;
using Core.Middlewares;
using Hangfire;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Declare Connection String
builder.Services.AddDbContext<ExamServiceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(ExamServiceDbContext).Assembly.FullName)));

#endregion

#region DependancyInjections
builder.Services
    .AddInfrastructureDependencies()
    .AddServiceDependencies(builder)
    .AddCoreDependencies();
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });
#endregion
#region AllowCORS
var CORS = "_cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORS,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});

#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//serilog
Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Services.AddSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors(CORS);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
// Map Hangfire Dashboard
app.MapHangfireDashboard();


app.Run();


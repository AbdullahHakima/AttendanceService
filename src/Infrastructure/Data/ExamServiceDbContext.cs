using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class ExamServiceDbContext : DbContext
{
    public ExamServiceDbContext()
    {
    }

    public ExamServiceDbContext(DbContextOptions<ExamServiceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizs { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentQuiz> StudentQuizzes { get; set; }

    public virtual DbSet<Submission> Submissions { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<AttendanceSession> AttendanceSessions { get; set; }
    public virtual DbSet<AttendanceRecord> AttendanceRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; Database=ExamServiceDb; Username=postgres; Password=282901");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("courses");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasMany(d => d.Courses).WithMany(p => p.Instructors)
                .UsingEntity<Dictionary<string, object>>(
                    "InstructorCourse",
                    r => r.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    l => l.HasOne<Instructor>().WithMany().HasForeignKey("InstructorId"),
                    j =>
                    {
                        j.HasKey("InstructorId", "CourseId");
                        j.ToTable("InstructorCourses");
                        j.HasIndex(new[] { "CourseId" }, "IX_InstructorCourses_CourseId");
                    });
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasIndex(e => e.QuizId, "IX_Modules_QuizId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Quiz).WithMany(p => p.Modules).HasForeignKey(d => d.QuizId);

            entity.HasMany(d => d.Questions).WithMany(p => p.Modules)
                .UsingEntity<Dictionary<string, object>>(
                    "ModuleQuestion",
                    r => r.HasOne<Question>().WithMany().HasForeignKey("QuestionId"),
                    l => l.HasOne<Module>().WithMany().HasForeignKey("ModuleId"),
                    j =>
                    {
                        j.HasKey("ModuleId", "QuestionId");
                        j.ToTable("ModuleQuestion");
                        j.HasIndex(new[] { "QuestionId" }, "IX_ModuleQuestion_QuestionId");
                    });
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasIndex(e => e.QuestionId, "IX_Options_QuestionId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Question).WithMany(p => p.Options).HasForeignKey(d => d.QuestionId);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasIndex(e => e.CourseId, "IX_Questions_CourseId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Course).WithMany(p => p.Questions).HasForeignKey(d => d.CourseId);
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasIndex(e => e.CourseId, "IX_Quizs_CourseId");

            entity.HasIndex(e => e.InstructorId, "IX_Quizs_InstructorId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Course).WithMany(p => p.Quizzes).HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.Instructor).WithMany(p => p.Quizzes).HasForeignKey(d => d.InstructorId);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasMany(d => d.Courses).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",
                    r => r.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    l => l.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                    j =>
                    {
                        j.HasKey("StudentId", "CourseId");
                        j.ToTable("StudentCourses");
                        j.HasIndex(new[] { "CourseId" }, "IX_StudentCourses_CourseId");
                    });
        });

        modelBuilder.Entity<StudentQuiz>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.QuizId });

            entity.HasIndex(e => e.ModuleId, "IX_StudentQuizzes_ModuleId");

            entity.HasIndex(e => e.QuizId, "IX_StudentQuizzes_QuizId");

            entity.HasIndex(e => e.SubmissionId, "IX_StudentQuizzes_SubmissionId");

            entity.HasOne(d => d.Module).WithMany(p => p.StudentQuizzes).HasForeignKey(d => d.ModuleId);

            entity.HasOne(d => d.Quiz).WithMany(p => p.StudentQuizzes).HasForeignKey(d => d.QuizId);

            entity.HasOne(d => d.Student).WithMany(p => p.StudentQuizzes).HasForeignKey(d => d.StudentId);

            entity.HasOne(d => d.Submission).WithMany(p => p.StudentQuizzes).HasForeignKey(d => d.SubmissionId);
        });

        modelBuilder.Entity<Submission>(entity =>
        {
            entity.HasIndex(e => e.ModuleId, "IX_Submissions_ModuleId");

            entity.HasIndex(e => e.StudentId, "IX_Submissions_StudentId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Module).WithMany(p => p.Submissions).HasForeignKey(d => d.ModuleId);

            entity.HasOne(d => d.Student).WithMany(p => p.Submissions).HasForeignKey(d => d.StudentId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

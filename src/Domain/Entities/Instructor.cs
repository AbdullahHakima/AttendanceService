namespace Data.Entities;

public partial class Instructor
{
    public Guid Id { get; set; }

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<AttendanceSession> AttendanceSessions { get; set; } // Navigation property

}

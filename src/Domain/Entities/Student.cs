namespace Data.Entities;

public partial class Student
{
    public Guid Id { get; set; }

    public string DisplayName { get; set; } = null!;

    public string AcademicId { get; set; } = null!;

    public virtual ICollection<StudentQuiz> StudentQuizzes { get; set; } = new List<StudentQuiz>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<AttendanceRecord> AttendanceRecords { get; set; } // Navigation property
}

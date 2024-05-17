namespace Data.Entities;

public partial class Quiz
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime StartedDate { get; set; }

    public DateTime ClosedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int Capacity { get; set; }

    public decimal Grade { get; set; }

    public double Duration { get; set; }

    public Guid InstructorId { get; set; }

    public Guid CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Instructor Instructor { get; set; } = null!;

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<StudentQuiz> StudentQuizzes { get; set; } = new List<StudentQuiz>();
}

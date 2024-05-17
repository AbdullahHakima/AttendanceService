namespace Data.Entities;

public partial class Submission
{
    public Guid Id { get; set; }

    public decimal TotalGrade { get; set; }

    public DateTime SubmitAt { get; set; }

    public TimeOnly TimeTaken { get; set; }

    public Guid StudentId { get; set; }

    public Guid ModuleId { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual ICollection<StudentQuiz> StudentQuizzes { get; set; } = new List<StudentQuiz>();
}

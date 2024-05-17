namespace Data.Entities;

public partial class StudentQuiz
{
    public Guid StudentId { get; set; }

    public Guid QuizId { get; set; }

    public Guid ModuleId { get; set; }

    public Guid? SubmissionId { get; set; }

    public bool Enrolled { get; set; }

    public int AttemptStatus { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual Quiz Quiz { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Submission? Submission { get; set; }
}

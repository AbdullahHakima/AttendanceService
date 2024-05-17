namespace Data.Entities;

public partial class Module
{
    public Guid Id { get; set; }

    public int? AssignedCapacity { get; set; }

    public string Name { get; set; } = null!;

    public decimal TotalGrade { get; set; }

    public Guid? QuizId { get; set; }

    public virtual Quiz? Quiz { get; set; }

    public virtual ICollection<StudentQuiz> StudentQuizzes { get; set; } = new List<StudentQuiz>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}

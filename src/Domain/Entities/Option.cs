namespace Data.Entities;

public partial class Option
{
    public Guid Id { get; set; }

    public string Text { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public Guid QuestionId { get; set; }

    public virtual Question Question { get; set; } = null!;
}

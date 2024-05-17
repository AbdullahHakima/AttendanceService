namespace Data.Entities;

public partial class Question
{
    public Guid Id { get; set; }

    public string Text { get; set; } = null!;

    public string ImageLink { get; set; } = null!;

    public decimal Points { get; set; }

    public decimal Duration { get; set; }

    public int Type { get; set; }

    public Guid CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Option> Options { get; set; } = new List<Option>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class AttendanceRecord
{
    public Guid Id { get; set; }

    [ForeignKey(nameof(AttendanceSessionId))]
    public Guid AttendanceSessionId { get; set; }
    public AttendanceSession AttendanceSession { get; set; } // Navigation property

    [ForeignKey(nameof(StudentId))]
    public Guid StudentId { get; set; }
    public Student Student { get; set; } // Navigation property

    public DateTimeOffset SubmissionTimestamp { get; set; }

    public double StudentLatitude { get; set; }

    public double StudentLongitude { get; set; }

    public AttendanceStatus Status { get; set; } // enum for present, absent, late, pending

    public string? Justification { get; set; } // optional for late/absent reasons
}


namespace Data.Entities;

public class AttendanceSession
{
    public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    public Instructor instructor { get; set; } // Navigation property
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public bool IsDynamic { get; set; }// which will use it for determine if the instructor use the pre-defined location or use a live one
    public Location? Location { get; set; } // Navigation property (one-to-one with Location)
    public double? Latitude { get; set; }//optional for dynamic locations
    public double? Longitude { get; set; }//optional for dynamic locations
    public double Radius { get; set; } // optional for dynamic locations
    public ICollection<AttendanceRecord> AttendanceRecords { get; set; } // Navigation property

    public Guid CourseId { get; set; }  // New foreign key property
    public Course Course { get; set; }  // New navigation property
}

namespace Data.Helpers.Dtos.AttendanceRecords;

public class AddAttendnaceRecordDto
{
    public DateTime SubmissionTimestamp { get; set; }

    public double StudentLatitude { get; set; }

    public double StudentLongitude { get; set; }

    public string? Justification { get; set; } // optional for late/absent reasons
}

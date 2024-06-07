namespace Data.Helpers.Dtos.AttedanceSessions;

public class ViewSessionDto
{
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public double Radius { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public string InstructorName { get; set; }
}

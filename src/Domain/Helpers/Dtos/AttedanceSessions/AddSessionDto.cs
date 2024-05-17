namespace Data.Helpers.Dtos.AttedanceSessions;

public class AddSessionDto
{
    public bool IsDynamic { get; set; }// which will use it for determine if the instructor use the pre-defined location or use a live one
    public Guid? PredefinedLocationId { get; set; }
    public double? Latitude { get; set; }//optional for dynamic locations
    public double? Longitude { get; set; }//optional for dynamic locations
    public double Radius { get; set; } // optional for dynamic locations
    public double Durantion { get; set; }
}
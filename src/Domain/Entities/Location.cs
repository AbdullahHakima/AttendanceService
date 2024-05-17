namespace Data.Entities;

public class Location
{
    public Guid Id { get; set; }
    public string Name { get; set; } // Descriptive name for the location (e.g., Classroom 101)
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Data.Helpers.Dtos.Locations;

public class AddLocationDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longitude { get; set; }
}

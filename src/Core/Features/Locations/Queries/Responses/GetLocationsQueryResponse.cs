using Data.Helpers.Dtos.Locations;

namespace Core.Features.Locations.Queries.Responses;

public class GetLocationsQueryResponse
{
    public List<ViewLocationDto> Locations { get; set; }
}

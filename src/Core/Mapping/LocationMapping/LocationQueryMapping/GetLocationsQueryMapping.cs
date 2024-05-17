using Core.Features.Locations.Queries.Responses;
using Data.Entities;
using Data.Helpers.Dtos.Locations;

namespace Core.Mapping.LocationMapping;

public partial class LocationProfile
{
    public void GetLocationsQueryMapping()
    {
        CreateMap<List<Location>, GetLocationsQueryResponse>()
            .ForMember(dest => dest.Locations, opt => opt.MapFrom(src => src.Select(l => new ViewLocationDto { Name = l.Name, Latitude = l.Latitude, Longitude = l.Longitude })));
    }
}

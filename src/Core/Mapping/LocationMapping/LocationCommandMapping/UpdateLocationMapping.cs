using Data.Entities;
using Data.Helpers.Dtos.Locations;

namespace Core.Mapping.LocationMapping;
public partial class LocationProfile
{
    public void UpdateLocationMapping()
    {
        CreateMap<UpdateLocationDto, Location>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}


using AutoMapper;

namespace Core.Mapping.LocationMapping;

public partial class LocationProfile : Profile
{
    public LocationProfile()
    {
        AddLocationMapping();
        ViewLocationMapping();
        GetLocationsQueryMapping();
        UpdateLocationMapping();
    }
}

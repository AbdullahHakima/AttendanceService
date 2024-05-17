using Data.Entities;

namespace Service.Interfaces;

public interface ILocationService
{
    Task<Location> AddLocationAsync(Location location);
    Task DeleteLocationAsync(Location location);
    Task<Location> GetLocationAsync(Guid id);
    Task UpdateLocationAsync(Location location);
    Task<List<Location>> GetLocationsAsync();

}

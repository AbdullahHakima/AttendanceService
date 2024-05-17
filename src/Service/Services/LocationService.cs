using Data.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service.Services;

public class LocationService : ILocationService
{
    #region Fields
    private readonly ILocationRepository _locationRepository;
    #endregion

    #region Constructors
    public LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    #endregion

    #region Methods
    public async Task<Location> AddLocationAsync(Location location)
    {
        return await _locationRepository.AddAsync(location);
    }

    public async Task DeleteLocationAsync(Location location)
    {
        await _locationRepository.DeleteAsync(location);
    }

    public async Task<Location?> GetLocationAsync(Guid id)
    {
        return await _locationRepository.FindAsync(l => l.Id == id);
    }

    public async Task<List<Location>> GetLocationsAsync()
    {
        return await _locationRepository.GetTableNoTracking()
                                        .ToListAsync();
    }

    public async Task UpdateLocationAsync(Location location)
    {
        await _locationRepository.UpdateAsync(location);
    }
    #endregion
}

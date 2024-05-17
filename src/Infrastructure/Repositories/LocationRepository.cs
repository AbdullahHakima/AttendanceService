using Data.Entities;
using Infrastructure.Bases;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LocationRepository : GenericRepositoryAsync<Location>, ILocationRepository
{
    private readonly DbSet<Location> _locationRepository;
    public LocationRepository(ExamServiceDbContext context) : base(context)
    {
        _locationRepository = context.Set<Location>();
    }
}

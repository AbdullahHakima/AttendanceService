using Core.Bases;
using Data.Helpers.Dtos.Locations;
using MediatR;

namespace Core.Features.Locations.Commands.Models.Updated;

public class UpdateLocationCommandModel : IRequest<Response<string>>
{
    public Guid locationId { get; set; }
    public UpdateLocationDto locationDto { get; set; }
}

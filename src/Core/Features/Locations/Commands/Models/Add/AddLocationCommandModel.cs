using Core.Bases;
using Data.Helpers.Dtos.Locations;
using MediatR;

namespace Core.Features.Locations.Commands.Models.Add;

public class AddLocationCommandModel : IRequest<Response<ViewLocationDto>>
{
    public AddLocationDto ViewLocationDto { get; set; }
}

using Core.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Core.Features.Locations.Commands.Models.Delete;

public class DeleteLocationCommandModel : IRequest<Response<string>>
{
    [Required]
    public Guid locationId { get; set; }
}

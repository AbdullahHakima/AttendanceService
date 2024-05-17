using Core.Bases;
using Core.Features.Locations.Queries.Responses;
using MediatR;

namespace Core.Features.Locations.Queries.Models;

public class GetLocationsQueryModel : IRequest<Response<GetLocationsQueryResponse>>
{
}

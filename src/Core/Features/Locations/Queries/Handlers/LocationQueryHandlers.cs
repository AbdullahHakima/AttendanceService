using AutoMapper;
using Core.Bases;
using Core.Features.Locations.Queries.Models;
using Core.Features.Locations.Queries.Responses;
using MediatR;
using Service.Interfaces;

namespace Core.Features.Locations.Queries.Handlers;

public class LocationQueryHandlers : ResponseHandler, IRequestHandler<GetLocationsQueryModel, Response<GetLocationsQueryResponse>>
{
    #region Fields
    private readonly ILocationService _locationService;
    private readonly IMapper _mapper;
    #endregion
    #region Constructors
    public LocationQueryHandlers(ILocationService locationService, IMapper mapper)
    {
        _locationService = locationService;
        _mapper = mapper;
    }


    #endregion

    #region Methods
    public async Task<Response<GetLocationsQueryResponse>> Handle(GetLocationsQueryModel request, CancellationToken cancellationToken)
    {
        var inquiredLocations = await _locationService.GetLocationsAsync();
        var mappedLocations = _mapper.Map<GetLocationsQueryResponse>(inquiredLocations);
        if (mappedLocations is null)
            return NotFound<GetLocationsQueryResponse>("There is no locations yet");
        return Success(mappedLocations);

    }
    #endregion
}

using AutoMapper;
using Core.Bases;
using Core.Features.Locations.Commands.Models.Add;
using Core.Features.Locations.Commands.Models.Delete;
using Core.Features.Locations.Commands.Models.Updated;
using Data.Entities;
using Data.Helpers.Dtos.Locations;
using MediatR;
using Service.Interfaces;

namespace Core.Features.Locations.Commands.Handlers;

public class LocationCommandHandlers : ResponseHandler, IRequestHandler<AddLocationCommandModel, Response<ViewLocationDto>>
                                                      , IRequestHandler<DeleteLocationCommandModel, Response<string>>
                                                      , IRequestHandler<UpdateLocationCommandModel, Response<string>>
{
    #region Fields
    private readonly ILocationService _locationService;
    private readonly IMapper _mapper;
    #endregion
    #region Constructors
    public LocationCommandHandlers(ILocationService locationService, IMapper mapper)
    {
        _locationService = locationService;
        _mapper = mapper;
    }


    #endregion
    #region Methods
    public async Task<Response<ViewLocationDto>> Handle(AddLocationCommandModel request, CancellationToken cancellationToken)
    {
        if (request.ViewLocationDto is null)
            return BadRequest<ViewLocationDto>(null, "you passed empty Location,please double check before send");
        var locationMapped = _mapper.Map<Location>(request.ViewLocationDto);
        if (locationMapped is null)
            return UnprocessableEntity<ViewLocationDto>("something occures will saving your location, please try again");
        var addedLocation = await _locationService.AddLocationAsync(locationMapped);
        var mappedLocation = _mapper.Map<ViewLocationDto>(locationMapped);
        return Created(mappedLocation);

    }

    public async Task<Response<string>> Handle(DeleteLocationCommandModel request, CancellationToken cancellationToken)
    {
        var inquiredLocation = await _locationService.GetLocationAsync(request.locationId);
        if (inquiredLocation is null)
            return NotFound<string>("there no location with this id");
        await _locationService.DeleteLocationAsync(inquiredLocation);
        return Deleted<string>();
    }

    public async Task<Response<string>> Handle(UpdateLocationCommandModel request, CancellationToken cancellationToken)
    {
        var inquiredLocation = await _locationService.GetLocationAsync(request.locationId);
        if (inquiredLocation is null)
            return NotFound<string>("there no location with this id");
        var mappedLocations = _mapper.Map(request.locationDto, inquiredLocation);
        if (mappedLocations is null) return BadRequest("something occure while process your updating request ,try again later");
        await _locationService.UpdateLocationAsync(mappedLocations);
        return Success("Location is updated successfuly");
    }
    #endregion
}

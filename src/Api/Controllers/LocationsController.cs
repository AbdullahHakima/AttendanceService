using Api.Base;
using Core.Features.Locations.Commands.Models.Add;
using Core.Features.Locations.Commands.Models.Delete;
using Core.Features.Locations.Commands.Models.Updated;
using Core.Features.Locations.Queries.Models;
using Data.Helpers.Dtos.Locations;
using Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
public class LocationsController : ApplicationController
{
    [HttpPost(Router.LocationRouting.AddLocation)]
    public async Task<IActionResult> AddLocation(AddLocationDto dto)
    {
        var response = await Mediator.Send(new AddLocationCommandModel { ViewLocationDto = dto });
        return NewResult(response);
    }
    [HttpGet(Router.LocationRouting.GetLocations)]
    public async Task<IActionResult> GetLocations()
    {
        var response = await Mediator.Send(new GetLocationsQueryModel { });
        return NewResult(response);
    }
    [HttpDelete(Router.LocationRouting.DeleteLocation)]
    public async Task<IActionResult> DeleteLocation([FromQuery] Guid locationId)
    {
        var response = await Mediator.Send(new DeleteLocationCommandModel { locationId = locationId });
        return NewResult(response);
    }
    [HttpPut(Router.LocationRouting.UpdateLocation)]
    public async Task<IActionResult> UpdateLocation([FromRoute] Guid locationId, [FromBody] UpdateLocationDto locationDto)
    {
        var response = await Mediator.Send(new UpdateLocationCommandModel { locationDto = locationDto, locationId = locationId });
        return NewResult(response);
    }
}

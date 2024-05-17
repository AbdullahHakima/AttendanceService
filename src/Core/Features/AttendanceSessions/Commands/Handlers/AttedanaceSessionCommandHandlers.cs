using AutoMapper;
using Core.Bases;
using Core.Features.AttendanceSessions.Commands.Models.Add;
using Data.Entities;
using Data.Helpers.Dtos.AttedanceSessions;
using MediatR;
using Service.Interfaces;

namespace Core.Features.AttendanceSessions.Commands.Handlers;

public class AttedanaceSessionCommandHandlers : ResponseHandler, IRequestHandler<AddSessionCommandModel, Response<ViewSessionDto>>
{
    #region Fields
    private readonly IAttendanceSessionService _attendanceSessionService;
    private readonly ILocationService _locationService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public AttedanaceSessionCommandHandlers(ILocationService locationService, IAttendanceSessionService attendanceSessionService, IMapper mapper)
    {
        _attendanceSessionService = attendanceSessionService;
        _locationService = locationService;
        _mapper = mapper;
    }
    #endregion

    #region Methods


    public async Task<Response<ViewSessionDto>> Handle(AddSessionCommandModel request, CancellationToken cancellationToken)
    {
        var mappedSession = _mapper.Map<AttendanceSession>(request);
        if (mappedSession == null)
            return BadRequest<ViewSessionDto>(null, "Something occures while initialize your session ,try again");
        else if (mappedSession.Location is not null)
        {
            var inquiredLocation = await _locationService.GetLocationAsync((Guid)request.sessionDto.PredefinedLocationId);
            mappedSession.Location = inquiredLocation;
        }
        var addedSession = await _attendanceSessionService.AddAttendanceSessionAsync(mappedSession);
        if (addedSession is null)
            return BadRequest<ViewSessionDto>(null, "Something occures while initialize your session ,try again");
        addedSession = await _attendanceSessionService.GetAttendanceSessionAsync(addedSession.Id);
        var viewSession = _mapper.Map<ViewSessionDto>(addedSession);
        return Success(viewSession);
    }
    #endregion

}

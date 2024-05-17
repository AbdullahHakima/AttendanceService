using AutoMapper;
using Core.Bases;
using Core.Features.AttendanceSessions.Queries.Models;
using Core.Features.AttendanceSessions.Queries.Responses;
using MediatR;
using Service.Interfaces;

namespace Core.Features.AttendanceSessions.Queries.Handlers;

public class AttendanceSessionQueryHandler : ResponseHandler, IRequestHandler<GetSessionQueryModel, Response<GetSessionQueryResponse>>
                                                            , IRequestHandler<GetSessionsQueryModel, Response<GetSessionsQueryResponse>>
{
    #region Fields
    private readonly IAttendanceSessionService _attendanceSessionService;
    private readonly IMapper _mapper;
    #endregion
    #region Constructors
    public AttendanceSessionQueryHandler(IAttendanceSessionService attendanceSessionService, IMapper mapper)
    {
        _attendanceSessionService = attendanceSessionService;
        _mapper = mapper;
    }
    #endregion
    #region Methods
    public async Task<Response<GetSessionQueryResponse>> Handle(GetSessionQueryModel request, CancellationToken cancellationToken)
    {
        var inquiredSession = await _attendanceSessionService.GetAttendanceSessionAsync(request.sessionId);
        if (inquiredSession is null)
            return NotFound<GetSessionQueryResponse>("The requested session not exist");
        var mappedSession = _mapper.Map<GetSessionQueryResponse>(inquiredSession);
        if (mappedSession is null)
            return BadRequest<GetSessionQueryResponse>(mappedSession, "something occures while process your request");
        return Success(mappedSession);
    }

    public async Task<Response<GetSessionsQueryResponse>> Handle(GetSessionsQueryModel request, CancellationToken cancellationToken)
    {
        var inquiredSessions = await _attendanceSessionService.GetAttendanceSessionsAsync(request.courseId);
        if (inquiredSessions is null)
            return NotFound<GetSessionsQueryResponse>("There is no session yet");
        var mappedSessions = _mapper.Map<GetSessionsQueryResponse>(inquiredSessions);
        if (mappedSessions is null)
            return BadRequest<GetSessionsQueryResponse>(mappedSessions, "something occures while process your request");
        return Success(mappedSessions);
    }
    #endregion

}

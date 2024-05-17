using AutoMapper;
using Core.Bases;
using Core.Features.AttendanceRecords.Commands.Models.Add;
using Data.Entities;
using MediatR;
using Service.Interfaces;

namespace Core.Features.AttendanceRecords.Commands.Handlers;

public class AttendnaceRecordCommandHandler : ResponseHandler, IRequestHandler<MarkAttendanceCommandModel, Response<string>>
{
    #region Fields
    private readonly IAttendanceRecordService _attendanceRecordService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public AttendnaceRecordCommandHandler(IAttendanceRecordService attendanceRecordService, IMapper mapper)
    {
        _attendanceRecordService = attendanceRecordService;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task<Response<string>> Handle(MarkAttendanceCommandModel request, CancellationToken cancellationToken)
    {
        var mappedRecord = _mapper.Map<AttendanceRecord>(request);
        if (mappedRecord is null)
            return BadRequest("something occure while processing your request");
        await _attendanceRecordService.InitializeAttendanceRecord(mappedRecord);
        return Success("Your attendnace successfuly saved and under processing");
    }
    #endregion

}

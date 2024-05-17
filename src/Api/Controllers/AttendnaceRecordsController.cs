using Api.Base;
using Core.Features.AttendanceRecords.Commands.Models.Add;
using Data.Helpers.Dtos.AttendanceRecords;
using Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
public class AttendnaceRecordsController : ApplicationController
{
    [HttpPost(Router.AttendnaceRecordRouting.MarkAttendnace)]
    public async Task<IActionResult> MarkAttendance([FromRoute] Guid studentId, [FromRoute] Guid sessionId
                                                  , [FromBody] AddAttendnaceRecordDto dto)
    {
        var response = await Mediator.Send(new MarkAttendanceCommandModel
        {
            recordDto = dto,
            sessionId = sessionId,
            studentId = studentId
        });
        return NewResult(response);
    }




}

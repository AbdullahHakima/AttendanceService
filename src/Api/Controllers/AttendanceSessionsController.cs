using Api.Base;
using Core.Features.AttendanceSessions.Commands.Models.Add;
using Core.Features.AttendanceSessions.Queries.Models;
using Data.Helpers.Dtos.AttedanceSessions;
using Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class AttendanceSessionsController : ApplicationController
    {
        [HttpPost(Router.AttendanceSessionRouting.AddSession)]
        public async Task<IActionResult> AddSession([FromRoute] Guid courseId, [FromRoute] Guid instructorId, [FromBody] AddSessionDto dto)
        {
            var response = await Mediator.Send(new AddSessionCommandModel { sessionDto = dto, instructorId = instructorId, courseId = courseId });
            return NewResult(response);
        }
        [HttpGet(Router.AttendanceSessionRouting.GetSession)]
        public async Task<IActionResult> GetSession([FromRoute] Guid sessionId)
        {
            var response = await Mediator.Send(new GetSessionQueryModel { sessionId = sessionId });
            return NewResult(response);
        }
        [HttpGet(Router.AttendanceSessionRouting.GetSessions)]
        public async Task<IActionResult> GetSessions([FromRoute] Guid courseId)
        {
            var response = await Mediator.Send(new GetSessionsQueryModel { courseId = courseId });
            return NewResult(response);

        }
    }
}

using Api.Base;
using Core.Features.Students.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ApplicationController
{
    [HttpGet("/Students/{Id}")]
    public async Task<IActionResult> GetStudentById(Guid Id)
    {
        var response = await Mediator.Send(new GetStudentByIdQueryModel { StudentId = Id });
        return NewResult(response);
    }
}

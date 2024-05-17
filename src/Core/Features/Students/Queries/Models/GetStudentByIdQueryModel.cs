using Core.Bases;
using Core.Features.Students.Queries.Response;
using MediatR;

namespace Core.Features.Students.Queries.Models;

public class GetStudentByIdQueryModel : IRequest<Response<GetStudentByIdQueryResponse>>
{
    public Guid StudentId { get; set; }
}

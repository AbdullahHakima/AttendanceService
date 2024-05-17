using AutoMapper;
using Core.Bases;
using Core.Features.Students.Queries.Models;
using Core.Features.Students.Queries.Response;
using MediatR;
using Service.Interfaces;

namespace Core.Features.Students.Queries.Handlers;

public class StudentQueryHandlers : ResponseHandler, IRequestHandler<GetStudentByIdQueryModel, Response<GetStudentByIdQueryResponse>>
{
    #region Fields
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public StudentQueryHandlers(IStudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task<Response<GetStudentByIdQueryResponse>> Handle(GetStudentByIdQueryModel request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudent(request.StudentId);
        if (student == null) return NotFound<GetStudentByIdQueryResponse>();
        var studentMapped = _mapper.Map<GetStudentByIdQueryResponse>(student);
        return Success(studentMapped);
    }
    #endregion
}

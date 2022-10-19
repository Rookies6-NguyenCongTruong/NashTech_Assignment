using Assignment1.DTOs;
using Assignment1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger, IStudentService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost]
    public AddStudentResponse Add([FromBody] AddStudentRequest addStudentRequest)
    {
        return _service.Create(addStudentRequest);
    }

    [HttpGet]
    public IEnumerable<GetStudentResponse> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public GetStudentResponse? GetById(int id)
    {
        return _service.GetById(id);
    }

    [HttpPut("{id}")]
    public UpdateStudentResponse? Update(int id, [FromBody] UpdateStudentRequest updateStudentRequest)
    {
        return _service.Update(id, updateStudentRequest);
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        return _service.Delete(id);
    }
}
using Assignment1.DTOs;

namespace Assignment1.Services;

public interface IStudentService
{
    public AddStudentResponse Create(AddStudentRequest createModel);
    public IEnumerable<GetStudentResponse> GetAll();
    public GetStudentResponse? GetById(int id);
    public UpdateStudentResponse? Update(int id, UpdateStudentRequest updateModel);
    public bool Delete(int id);
}
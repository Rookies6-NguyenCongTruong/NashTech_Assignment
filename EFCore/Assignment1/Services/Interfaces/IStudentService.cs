using Assignment1.DTOs;

namespace Assignment1.Services;

public interface IStudentService
{
    AddStudentResponse Create(AddStudentRequest createModel);
    IEnumerable<GetStudentResponse> GetAll();
    GetStudentResponse? GetById(int id);
    UpdateStudentResponse? Update(int id, UpdateStudentRequest updateModel);
    bool Delete(int id);
}
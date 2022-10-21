using Assignment1.DTOs;
using Assignment1.Models;
using Assignment1.Repositories;

namespace Assignment1.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepo;

    public StudentService(IStudentRepository studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public AddStudentResponse Create(AddStudentRequest createModel)
    {
        var createStudent = new Student
        {
            FirstName = createModel.FirstName,
            LastName = createModel.LastName,
            City = createModel.City,
            State = createModel.State
        };

        var student = _studentRepo.Create(createStudent);

        _studentRepo.SaveChanges();

        return new AddStudentResponse
        {
            StudentId = student.StudentId,
            FirstName = student.FirstName
        };
    }

    public bool Delete(int id)
    {
        var deletestudent = _studentRepo.Get(s => s.StudentId == id);

        if (deletestudent != null)
        {
            bool result = _studentRepo.Delete(deletestudent);

            _studentRepo.SaveChanges();

            return result;
        }

        return false;
    }

    public IEnumerable<GetStudentResponse> GetAll()
    {
        var list = _studentRepo.GetAll(s => true).Select(student => new GetStudentResponse
        {
            StudentId = student.StudentId,
            FirstName = student.FirstName,
            LastName = student.LastName,
            City = student.City,
            State = student.State
        });

        return list;
    }

    public GetStudentResponse? GetById(int id)
    {
        var requestStudent = _studentRepo.Get(s => s.StudentId == id);

        if (requestStudent != null)
        {
            return new GetStudentResponse
            {
                StudentId = requestStudent.StudentId,
                FirstName = requestStudent.FirstName,
                LastName = requestStudent.LastName,
                City = requestStudent.City,
                State = requestStudent.State
            };
        }

        return null;
    }

    public UpdateStudentResponse? Update(int id, UpdateStudentRequest updateModel)
    {
        var student = _studentRepo.Get(s => s.StudentId == id);

        if (student != null)
        {
            student.FirstName = updateModel.FirstName;
            student.LastName = updateModel.LastName;
            student.City = updateModel.City;
            student.State = updateModel.State;

            var updateStudent = _studentRepo.Update(student);

            _studentRepo.SaveChanges();

            return new UpdateStudentResponse
            {
                StudentId = student.StudentId,
                FirstName = updateStudent.FirstName,
                LastName = updateStudent.LastName,
                City = updateStudent.City,
                State = updateStudent.State
            };
        }

        return null;
    }
}
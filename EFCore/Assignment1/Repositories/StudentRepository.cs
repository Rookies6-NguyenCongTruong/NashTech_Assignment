using Assignment1.Models;

namespace Assignment1.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(StudentContext context) : base(context)
    {
    }
}
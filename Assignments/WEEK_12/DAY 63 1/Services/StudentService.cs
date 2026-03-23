using AdaptiveStudentDataLayer.Models;
using AdaptiveStudentDataLayer.Repositories;
using AdaptiveStudentDataLayer.Models;
using AdaptiveStudentDataLayer.Repositories;

public class StudentService : IStudentService
{
    private readonly IStudentRepository repo;

    public StudentService(IStudentRepository repo)
    {
        this.repo = repo;
    }

    public void Add(Student student)
    {
        if (student.Grade < 0 || student.Grade > 100)
            throw new Exception("Grade must be between 0–100");

        repo.Add(student);
    }

    public IEnumerable<Student> GetAll()
    {
        return repo.GetAll();
    }

    public void Update(Student student)
    {
        repo.Update(student);
    }

    public void Delete(int id)
    {
        repo.Delete(id);
    }
}
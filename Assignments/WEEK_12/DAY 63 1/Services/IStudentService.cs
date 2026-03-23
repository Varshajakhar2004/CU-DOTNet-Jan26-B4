using AdaptiveStudentDataLayer.Models;

public interface IStudentService
{
    void Add(Student student);
    IEnumerable<Student> GetAll();
    void Update(Student student);
    void Delete(int id);
}
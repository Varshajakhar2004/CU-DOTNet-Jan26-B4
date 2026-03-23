using AdaptiveStudentDataLayer.Models;
using AdaptiveStudentDataLayer.Repositories;
using AdaptiveStudentDataLayer.Models;

public class ListStudentRepository : IStudentRepository
{
    private List<Student> students = new List<Student>();

    public void Add(Student student)
    {
        students.Add(student);
    }

    public IEnumerable<Student> GetAll()
    {
        return students;
    }

    public void Update(Student student)
    {
        var s = students.FirstOrDefault(x => x.Id == student.Id);
        if (s != null)
        {
            s.Name = student.Name;
            s.Grade = student.Grade;
        }
    }

    public void Delete(int id)
    {
        var s = students.FirstOrDefault(x => x.Id == id);
        if (s != null)
            students.Remove(s);
    }
}
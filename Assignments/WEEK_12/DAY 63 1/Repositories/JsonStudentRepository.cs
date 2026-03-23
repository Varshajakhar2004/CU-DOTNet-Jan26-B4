using AdaptiveStudentDataLayer.Models;
using AdaptiveStudentDataLayer.Repositories;
using AdaptiveStudentDataLayer.Models;
using System.Text.Json;

public class JsonStudentRepository : IStudentRepository
{
    private string path = "students.json";

    private List<Student> ReadFile()
    {
        if (!File.Exists(path)) return new List<Student>();
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
    }

    private void WriteFile(List<Student> students)
    {
        var json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    public void Add(Student student)
    {
        var list = ReadFile();
        list.Add(student);
        WriteFile(list);
    }

    public IEnumerable<Student> GetAll()
    {
        return ReadFile();
    }

    public void Update(Student student)
    {
        var list = ReadFile();
        var s = list.FirstOrDefault(x => x.Id == student.Id);

        if (s != null)
        {
            s.Name = student.Name;
            s.Grade = student.Grade;
            WriteFile(list);
        }
    }

    public void Delete(int id)
    {
        var list = ReadFile();
        var s = list.FirstOrDefault(x => x.Id == id);

        if (s != null)
        {
            list.Remove(s);
            WriteFile(list);
        }
    }
}
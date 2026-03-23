using AdaptiveStudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveStudentDataLayer.Repositories
{
    public interface IStudentRepository
    {
        void Add(Student student);
        IEnumerable<Student> GetAll();
        void Update(Student student);
        void Delete(int id);
    }
}

namespace week_4
{
    //entity class
    class Student1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }

        public override string ToString()
        {
            return $"Id- {Id}, Name -{Name}, Marks-{Marks}";
        }
    }
    //manager class
    class StudentManager
    {
        Dictionary<int, Student1> studentsData = new Dictionary<int, Student1>();
        public bool AddStudents(Student1 student)
        {
            int id = student.Id;
            if (!studentsData.ContainsKey(id))
            {
                studentsData.Add(id, student);
                return true;
            }
            return false;
        }

        public void DisplayAllStudents()
        {
            foreach (var student in studentsData)
            {
                Console.WriteLine(student.Value);
            }

        }

        public Student1 SearchStudent(int id)
        {
            Student1 student = null;
            bool found =  studentsData.TryGetValue(id, out student);
            return  student;
        }

        public bool UpdateStudent(int id, int marks)
        {
            Student1 foundStudent = SearchStudent(id);
            if (foundStudent != null)
            {
                foundStudent.Marks = marks;
                return true;        
            }
            return false;
        }


        public bool DeleteStudent(int id)
        {

            return studentsData.Remove(id);
        }   
        
    }
    internal class StudentManagementSystem  //class used for usemanager
    {
        static void Main(string[] args)
        {
            Console.WriteLine("STUDENT MANAGEMENT SYSTEM");
            Console.WriteLine("----------------------------");

            StudentManager manager = new StudentManager();
            int choice; // Declare choice variable outside the loop

            do
            {
                Console.WriteLine("Add Student-1 ");
                Console.WriteLine("Search Student-2 ");
                Console.WriteLine("Update Student-3");
                Console.WriteLine("Delete Student - 4");
                Console.WriteLine("Display Student-5");
                Console.WriteLine("Exit -6 ");

                Console.WriteLine("enter you operation to do -");

                choice = int.Parse(Console.ReadLine()); // Assign value inside the loop

                switch (choice)
                {
                    case 1:
                        Student1 student = new Student1();
                        Console.WriteLine("Enter ID");
                        student.Id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Name");
                        student.Name = (Console.ReadLine());

                        Console.WriteLine("Enter Marks");
                        student.Marks = int.Parse(Console.ReadLine());

                        bool added = manager.AddStudents(student);
                        Console.WriteLine(added ? "Student added" : "student already exists");
                        break;

                    case 2:
                        Console.WriteLine("Enter Id to search student");
                        int SearchId = int.Parse(Console.ReadLine());

                        Student1 foundStudent = manager.SearchStudent(SearchId);
                        if (foundStudent == null)
                            Console.WriteLine($"Student with {SearchId} not found ");
                        else
                            Console.WriteLine(foundStudent);
                        break;

                    case 3:
                        Console.WriteLine("Enter Id to update");
                        int UpdateId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter marks to update");
                        int marks = int.Parse(Console.ReadLine());

                        bool updated = manager.UpdateStudent(UpdateId, marks);
                        if (updated)
                        {
                            Console.WriteLine(manager.SearchStudent(UpdateId));
                        }
                        break;

                    case 4:

                        Console.WriteLine("Enter Id to delete");
                        int DeleteId = int.Parse(Console.ReadLine());

                        bool deleted = manager.DeleteStudent(DeleteId);
                        if (deleted)
                        {
                            Console.WriteLine("student deleted");
                        }
                        break;

                    case 5:
                        manager.DisplayAllStudents();
                        break;

                    default:
                        Console.WriteLine("error");
                        break;

                }
            } while (choice != 6);

          Console.WriteLine("Program ended---------------------------"
        }
    }
}

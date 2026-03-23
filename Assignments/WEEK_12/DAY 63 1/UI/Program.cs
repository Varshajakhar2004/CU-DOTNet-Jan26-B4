using AdaptiveStudentDataLayer.Models;
using AdaptiveStudentDataLayer.Repositories;
using AdaptiveStudentDataLayer.UI;

namespace AdaptiveStudentDataLayer.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====== Student Management System ======");
            Console.WriteLine("Select Storage Method:");
            Console.WriteLine("1. In-Memory (List)");
            Console.WriteLine("2. JSON File");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            IStudentRepository repo = choice == 1
                ? new ListStudentRepository()
                : new JsonStudentRepository();

            IStudentService service = new StudentService(repo);

            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                try
                {
                    switch (option)
                    {
                        case 1:
                            AddStudent(service);
                            break;

                        case 2:
                            ViewStudents(service);
                            break;

                        case 3:
                            UpdateStudent(service);
                            break;

                        case 4:
                            DeleteStudent(service);
                            break;

                        case 5:
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void AddStudent(IStudentService service)
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Grade (0-100): ");
            int grade = int.Parse(Console.ReadLine());

            service.Add(new Student
            {
                Id = id,
                Name = name,
                Grade = grade
            });

            Console.WriteLine("Student added successfully!");
        }

        static void ViewStudents(IStudentService service)
        {
            var students = service.GetAll();

            Console.WriteLine("\n--- Student List ---");
            foreach (var s in students)
            {
                Console.WriteLine(s);
            }
        }

        static void UpdateStudent(IStudentService service)
        {
            Console.Write("Enter Id to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter New Grade: ");
            int grade = int.Parse(Console.ReadLine());

            service.Update(new Student
            {
                Id = id,
                Name = name,
                Grade = grade
            });

            Console.WriteLine("Student updated successfully!");
        }

        static void DeleteStudent(IStudentService service)
        {
            Console.Write("Enter Id to delete: ");
            int id = int.Parse(Console.ReadLine());

            service.Delete(id);

            Console.WriteLine("Student deleted successfully!");
        }
    }
}
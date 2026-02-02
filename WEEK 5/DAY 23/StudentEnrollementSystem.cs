using System.Text.RegularExpressions;

namespace Week_5
{
    class InvalidStudentAgeException : Exception
    {
        public InvalidStudentAgeException(string message) : base(message)
        {

        }
    }

    class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException(string message) : base(message)
        {

        }
    }

    internal class StudentEnrollementSystem
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------STUDENT ENROLLEMENT SYSTEM-------");
            //custom exceptions
            int age = 0;

            while(true)
            {
                try
                {
                    Console.WriteLine("Enter the age- ");
                    age = int.Parse(Console.ReadLine());
                    if (age < 18 || age > 60)
                        throw new InvalidStudentAgeException("Age must be between 18 and 60");
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Invalid :" + ex.Message);
                }
            }

            string name = " ";
            while(true)
            {
                try
                {
                    Console.WriteLine("Enter Name of student:");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                        throw new InvalidStudentNameException("Name can not be blank");
                    bool isValidName = Regex.IsMatch(name, @"^[A-Z]{1}[a-z]+$");
                    if (!isValidName)
                        throw new InvalidStudentNameException("Name must start with a capital letter followed by lowercase letters");
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Invalid:" + ex.Message);
                }
            }

            //built in exceptions

            try
            {
                Console.WriteLine("Enter the numerator:");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the denominator");
                int deno = int.Parse(Console.ReadLine());
                Console.WriteLine($"Division result: {num/deno}");
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Error: denominator can not be zero");
            }
            
            finally
            {
                Console.WriteLine("DivideByZeroException done");
            }

            try
            {
                Console.WriteLine("Enter the marks :");
                int n = int.Parse(Console.ReadLine());
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Error : please enter valid numbers");
            }
            finally
            {
                Console.WriteLine("FormatException done");
            }

            int[] arr = { 10, 20, 35, 46, 58, 69, 70, 81 };
            try
            {
                Console.Write("Array index: ");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine("Value: " + arr[index]);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index is out of range ");
            }

            catch(Exception ex)// inner exception 
            {
                Console.WriteLine("\n--- Inner Exception Demo ---");
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Inner: " + ex.InnerException.Message);
                Console.WriteLine("Stack Trace:\n" + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("built in exceptions done");
            }
        }
    }
}

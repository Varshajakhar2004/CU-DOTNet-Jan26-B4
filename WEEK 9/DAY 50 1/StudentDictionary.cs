using System;
using System.Collections.Generic;

namespace Class_Practice
{
    public class Student
    {
        public int StudId { get; set; }
        public string SName { get; set; }

        public Student()
        {
        }

        public Student(int studId, string sName)
        {
            StudId = studId;
            SName = sName;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Student stemp)
            {
                return this.StudId == stemp.StudId &&
                       this.SName == stemp.SName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StudId, SName);
        }
    }

    internal class StudentDictionary
    {
        static void AddStudent(Dictionary<Student, int> dict, Student student, int marks)
        {
            if (dict.ContainsKey(student))
            {
                Console.WriteLine($"Student {student.SName} already exists. Updating marks...");
                dict[student] = marks;  // Update
            }
            else
            {
                Console.WriteLine($"Adding new student {student.SName}...");
                dict.Add(student, marks);  // Add
            }
        }

        static void Main(string[] args)
        {
            Dictionary<Student, int> dict = new Dictionary<Student, int>();

            Student s1 = new Student { StudId = 1, SName = "Varsha" };
            Student s2 = new Student { StudId = 2, SName = "Rahul" };
            Student s3 = new Student { StudId = 1, SName = "Varsha" };

            AddStudent(dict, s1, 80);
            AddStudent(dict, s2, 75);
            AddStudent(dict, s3, 90); 

            Console.WriteLine("\nFinal Student Marks:\n");

            foreach (var item in dict)
            {
                Console.WriteLine($"ID: {item.Key.StudId}, Name: {item.Key.SName}, Marks: {item.Value}");
            }
        }
    }
}
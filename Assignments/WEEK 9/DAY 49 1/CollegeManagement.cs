using System;
using System.Collections.Generic;
using System.Linq;

namespace week09
{
    public class Program
    {
        class CollageManagement
        {
            Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, List<string>> subjectOrder = new Dictionary<string, List<string>>();

            public void AddStudent(string studentId, string subject, int marks)
            {
                if (!studentRecords.ContainsKey(studentId))
                    studentRecords[studentId] = new Dictionary<string, int>();

                if (!studentRecords[studentId].ContainsKey(subject))
                {
                    studentRecords[studentId][subject] = marks;

                    if (!subjectOrder.ContainsKey(subject))
                        subjectOrder[subject] = new List<string>();

                    subjectOrder[subject].Add(studentId);
                }
                else
                {
                    if (marks > studentRecords[studentId][subject])
                        studentRecords[studentId][subject] = marks;
                }
            }

            public void RemoveStudent(string studentId)
            {
                if (!studentRecords.ContainsKey(studentId)) return;

                foreach (var subject in studentRecords[studentId].Keys)
                {
                    if (subjectOrder.ContainsKey(subject))
                        subjectOrder[subject].Remove(studentId);
                }

                studentRecords.Remove(studentId);
            }

            public void TopStudent(string subject)
            {
                if (!subjectOrder.ContainsKey(subject)) return;

                int maxMarks = -1;

                foreach (var studentId in subjectOrder[subject])
                {
                    int marks = studentRecords[studentId][subject];
                    if (marks > maxMarks) maxMarks = marks;
                }

                foreach (var studentId in subjectOrder[subject])
                {
                    if (studentRecords[studentId][subject] == maxMarks)
                        Console.WriteLine(studentId + " " + maxMarks);
                }
            }

            public void Result()
            {
                foreach (var student in studentRecords)
                {
                    double avg = student.Value.Values.Average();
                    Console.WriteLine(student.Key + " " + avg.ToString("F2"));
                }
            }
        }

        static void Main(string[] args)
        {
            CollageManagement cm = new CollageManagement();

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;

                string[] parts = input.Split(' ');

                switch (parts[0].ToUpper())
                {
                    case "ADD":
                        cm.AddStudent(parts[1], parts[2], int.Parse(parts[3]));
                        break;
                    case "REMOVE":
                        cm.RemoveStudent(parts[1]);
                        break;
                    case "TOP":
                        cm.TopStudent(parts[1]);
                        break;
                    case "RESULT":
                        cm.Result();
                        break;
                }
            }
        }
    }
}

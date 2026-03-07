using System.Collections;

namespace Week_5
{
    internal class LegacyEmployeeDirectory
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "Alice");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");

            if(!employeeTable.ContainsKey(105))
            {
                employeeTable.Add(105, "Edward");
            }
            else
            {
                Console.WriteLine("ID already exists");
            }

            string employeeName = (string)employeeTable[102];
            Console.WriteLine($"Name of employee with 102 ID: {employeeName}");

            Console.WriteLine("Employee records:");
            foreach (DictionaryEntry entry in employeeTable)
            {
                Console.WriteLine($"Id:{entry.Key}, Name:{entry.Value}");
            }


            employeeTable.Remove(103);
            Console.WriteLine("after removal of 103 employee");
            Console.WriteLine($"Total employees:{employeeTable.Count}");
        }
    }
}

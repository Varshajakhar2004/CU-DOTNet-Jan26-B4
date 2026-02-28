using System;
using System.Data;
using Week08Assessment.Library;

namespace Week08Assessment
{
    internal class employee
    {
        static void Main(string[] args)
        {
            EmployeeBonus emp = new EmployeeBonus
            {
                BaseSalary = 500000,
                PerformanceRating = 5,
                YearsOfExperience = 6,
                DepartmentMultiplier = 1.1m,
                AttendancePercentage = 95
            };

            Console.WriteLine("Employee Bonus Calculation:");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Final Net Annual Bonus of the employee is : {emp.NetAnnualBonus}");

        }
    }
}
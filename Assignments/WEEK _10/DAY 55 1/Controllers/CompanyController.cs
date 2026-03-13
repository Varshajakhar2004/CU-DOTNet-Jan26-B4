using Microsoft.AspNetCore.Mvc;
using TheCorporatePulsePortal.Models;

namespace TheCorporatePulsePortal.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Dashboard()
        {

            List<Employee> employees = new List<Employee>()
            {
                new Employee { EmpId = 1, EmpName = "Varsha", Position = "Software Developer", Salary = 60000 },
                new Employee { EmpId = 2, EmpName = "Suraj", Position = "UI Designer", Salary = 55000 },
                new Employee { EmpId = 3, EmpName = "ABCD", Position = "Project Manager", Salary = 80000 },
                new Employee { EmpId = 4, EmpName = "Neha", Position = "QA Engineer", Salary = 50000 },
                new Employee { EmpId = 5, EmpName = "Rahul Sharma", Position = "Software Developer", Salary = 60000 },
    new Employee { EmpId = 6, EmpName = "Priya Mehta", Position = "UI Designer", Salary = 55000 },
    new Employee { EmpId = 7, EmpName = "Amit Verma", Position = "Project Manager", Salary = 80000 },
    new Employee { EmpId = 8, EmpName = "Neha Gupta", Position = "QA Engineer", Salary = 50000 },
    new Employee { EmpId = 9, EmpName = "Arjun Singh", Position = "Backend Developer", Salary = 65000 },
    new Employee { EmpId = 10, EmpName = "Kavita Sharma", Position = "Frontend Developer", Salary = 62000 },
    new Employee { EmpId = 11, EmpName = "Rohit Kapoor", Position = "System Analyst", Salary = 70000 },
    new Employee { EmpId = 12, EmpName = "Sneha Jain", Position = "Business Analyst", Salary = 68000 },
    new Employee { EmpId = 13, EmpName = "Vikas Malhotra", Position = "Database Administrator", Salary = 72000 },
    new Employee { EmpId = 14, EmpName = "Pooja Arora", Position = "HR Manager", Salary = 58000 },
    new Employee { EmpId = 15, EmpName = "Karan Khanna", Position = "DevOps Engineer", Salary = 75000 },
    new Employee { EmpId = 16, EmpName = "Meera Nair", Position = "Software Tester", Salary = 52000 },
    new Employee { EmpId = 17, EmpName = "Ankit Bansal", Position = "Full Stack Developer", Salary = 78000 },
    new Employee { EmpId = 18, EmpName = "Riya Choudhary", Position = "UI/UX Designer", Salary = 56000 },
    new Employee { EmpId = 19, EmpName = "Deepak Yadav", Position = "Support Engineer", Salary = 48000 },
    new Employee { EmpId = 20, EmpName = "Simran Kaur", Position = "Product Owner", Salary = 82000 },
    new Employee { EmpId = 21, EmpName = "Manish Tiwari", Position = "Security Analyst", Salary = 74000 },
    new Employee { EmpId = 22, EmpName = "Nikita Sharma", Position = "Technical Writer", Salary = 50000 },
    new Employee { EmpId = 23, EmpName = "Aditya Raj", Position = "Cloud Engineer", Salary = 77000 },
    new Employee { EmpId = 24, EmpName = "Shreya Sen", Position = "Data Analyst", Salary = 69000 },
    new Employee { EmpId = 25, EmpName = "Rakesh Kumar", Position = "Network Engineer", Salary = 64000 },
    new Employee { EmpId = 26, EmpName = "Anjali Verma", Position = "Scrum Master", Salary = 73000 },
    new Employee { EmpId = 27, EmpName = "Tarun Gupta", Position = "Mobile App Developer", Salary = 71000 },
    new Employee { EmpId = 28, EmpName = "Pallavi Sinha", Position = "Content Strategist", Salary = 54000 },
    new Employee { EmpId = 29, EmpName = "Harsh Agarwal", Position = "AI Engineer", Salary = 85000 }
            };

            ViewBag.Announcement = "Daily Announcement: Team meeting today at 4 PM.";

            ViewData["DepartmentName"] = "Software Development";
            ViewData["IsActive"] = true;

            return View(employees);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

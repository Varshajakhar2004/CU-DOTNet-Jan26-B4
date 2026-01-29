namespace week_4
{
    class Employee
    {

        public Employee()
        {
            EmployeeId = 0;
            EmployeeName = string.Empty;
            BasicSalary = 0.0M;
            ExperienceInYears = 0;
        }

        public Employee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            BasicSalary = basicSalary;
            ExperienceInYears = experienceInYears;
        }

        public decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Employee Id - {EmployeeId}");
            Console.WriteLine($"Employee Name - {EmployeeName}");
            Console.WriteLine($"Basic Salary - {BasicSalary}");
            Console.WriteLine($"Experience In Years - {ExperienceInYears}");
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYears { get; set; }
    }

    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int EmployeeId, string EmployeeName, decimal BasicSalary, int ExperienceInYears) : base (EmployeeId, EmployeeName, BasicSalary, ExperienceInYears)
        {
        }


        public new decimal CalculateAnnualSalary()
        {
            decimal hra = BasicSalary * 0.2M;
            decimal specialAllowance = BasicSalary * 0.10M;
            decimal loyaltybous = (ExperienceInYears >= 5) ? 50000M : 0M;

            decimal monthlySalary = BasicSalary + hra + specialAllowance ;
            decimal AnnualSalary = (monthlySalary * 12) + loyaltybous ;
            return AnnualSalary;
        }
    }

    class ContractEmployee : Employee
    {

        public int ContractDurationInMonths { get; set; }
        public ContractEmployee(int contractDurationInMonths,int employeeId,string employeeName,decimal basicSalary, int experienceInYears) : base (employeeId, employeeName, basicSalary, experienceInYears)
        {
            int ContractDurationInMonths = contractDurationInMonths;
        }


        public new decimal CalculateAnnualSalary()
        {
            decimal bonus = (ContractDurationInMonths >= 12) ? 30000M : 0M;
            decimal AnnualSalary = (BasicSalary * 12) + bonus;
            return AnnualSalary;
        }
    }

    class InternEmployee : Employee
    {
        public int FixedStipend { get; set; }

        public InternEmployee( int fixedStipend, int employeeId, string employeeName, int experienceInYears) : base(employeeId, employeeName,0M, 0)
        {
            FixedStipend = fixedStipend;
        }


        public new decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = FixedStipend * 12;
            return AnnualSalary;
        }
    }


    internal class EmployeeCompensationManagement
    {
        static void Main(string[] args)
        {

            Employee e1 = new Employee(1, "VARSHA", 30000M, 3);

            PermanentEmployee p1 = new PermanentEmployee(2, "SURAJ", 50000M, 6);
            ContractEmployee c1 = new ContractEmployee(18, 3, "Suresh", 40000M, 4);
            InternEmployee i1 = new InternEmployee(15000, 4, "ANKIT", 0);

            Console.WriteLine("Using Base Class Reference:\n");

            Console.WriteLine(e1.CalculateAnnualSalary()); 
            Console.WriteLine(p1.CalculateAnnualSalary()); 
            Console.WriteLine(c1.CalculateAnnualSalary());
            Console.WriteLine(i1.CalculateAnnualSalary()); 

            Console.WriteLine("\nUsing Base Reference pointing to Derived Object:\n");

            Employee emp = new PermanentEmployee(5, "Kiran", 60000M, 7);
            Console.WriteLine(emp.CalculateAnnualSalary()); 

            Console.WriteLine("\nUsing Derived Reference:\n");

            PermanentEmployee p2 = new PermanentEmployee(6, "Riya", 55000M, 5);
            Console.WriteLine(p2.CalculateAnnualSalary()); 

        }
    }
}

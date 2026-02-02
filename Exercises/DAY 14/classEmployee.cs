namespace OOPs
{

    class Employee
    {
        string employeeName = string.Empty;

        public void SetName(string name)   // taking name
        {
            employeeName = name;
        }
        public void GetName()
        {
            Console.WriteLine($"{employeeName}");
        }

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name { get; set; }

        private string department;

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set { 
                if(value>50000 && value<90000)
                salary = value; }
        }
        public void DisplayName()
        {
            Console.WriteLine($"DisplayName : {employeeName}");
        }
         public void DisplayID()
        {
            Console.WriteLine($"DisplayID :{ID}");
        }
        public void DisplayDepartment()
        {
            Console.WriteLine($"DisplayDepartment : {department}");
        }
        public void DisplaySalary()
        {
            Console.WriteLine($"DisplaySalary : {salary}");
        }
        public void DisplayAll()
        {
            Console.WriteLine("\n--- Employee Details ---");
            Console.WriteLine($"Name: {employeeName}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Department: {department}");
            Console.WriteLine($"Salary: {salary}");
        }
    }
    class classEmployee
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            Console.WriteLine("Enter Employee Name");
            string name = Console.ReadLine();
            emp.SetName(name);

            Console.WriteLine("Enter ID");
            emp.ID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Department:");
            emp.Department = Console.ReadLine();

            Console.WriteLine("Enter Salary:");
            emp.Salary = int.Parse(Console.ReadLine());

            emp.DisplayAll();
        }
    }
}

namespace week_4
{
    public class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; }

        public Patient(string name, decimal baseFee)
        {
            Name = name;
            BaseFee = baseFee;
        }

        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }

    public class Inpatient : Patient
    {
        public int DaysStayed { get; set; }
        public decimal DailyRate { get; set; }

        public Inpatient(string name, decimal baseFee, int daysStayed, decimal dailyRate) : base(name , baseFee)
        {
            DaysStayed = daysStayed;
            DailyRate = dailyRate;
        }

        public override decimal CalculateFinalBill()
        {
            return BaseFee +(DaysStayed*DailyRate);
        }

    }

    public class Outpatient : Patient
    {
        public decimal ProcedureFee { get; set; }

        public Outpatient(string name, decimal baseFee, decimal procedureFee) : base(name, baseFee)
        {
            ProcedureFee = procedureFee;
        }

        public override decimal CalculateFinalBill()
        {
            return BaseFee + ProcedureFee;
        }
    }

    public class EmergencyPatient : Patient
    {
        public int SeverityLevel { get; set; }

        public EmergencyPatient(string name, decimal baseFee, int severityLevel) : base(name, baseFee)
        {
            SeverityLevel = severityLevel;
        }

        public override decimal CalculateFinalBill()
        {
            return BaseFee * SeverityLevel;
        }
        
    }


    public class HospitalBilling
    {
        private List<Patient> patients = new List<Patient>();

        public virtual void AddPatient(Patient p)
        {
            patients.Add(p);
        }

        public void GenerateDailyReport()
        {
            Console.WriteLine("----------DAILY REPORT-------------");
            foreach (var p in patients)
            {
                Console.WriteLine($"{p.Name}:{p.CalculateFinalBill()}");
            }
        }

        public decimal TotalRevenue()
        {
            decimal totalRevenue = 0;
            foreach (var p in patients)
            {
                totalRevenue += p.CalculateFinalBill();
            }
            return totalRevenue;
        }


        public int GetInpatientCount()
        {
            int count = 0;
            foreach (var p in patients)
            {
                if (p is Inpatient)
                    count++;
            }
            return count;
        }
    }
    internal class Week04Assessment
    {
        static void Main(string[] args)
        {

            HospitalBilling hospital = new HospitalBilling();

            hospital.AddPatient(new Inpatient("ram", 500, 3, 200));      
            hospital.AddPatient(new Outpatient("shyam", 900, 150));   
            hospital.AddPatient(new EmergencyPatient("geeta", 400, 4));
            hospital.AddPatient(new Inpatient("abc", 500, 4, 200));
            hospital.AddPatient(new Outpatient("def", 500, 400));
            hospital.AddPatient(new Inpatient("ghi", 500, 15, 600));
            hospital.AddPatient(new Outpatient("jkl", 500, 500));
            hospital.AddPatient(new Inpatient("mno", 500, 2, 200));
            hospital.AddPatient(new EmergencyPatient("pqr", 500, 3));



            hospital.GenerateDailyReport();

            Console.WriteLine($"Total Revenue: {hospital.TotalRevenue():C2}");

            Console.WriteLine($"Total Inpatients: {hospital.GetInpatientCount()}");


        }
    }
}

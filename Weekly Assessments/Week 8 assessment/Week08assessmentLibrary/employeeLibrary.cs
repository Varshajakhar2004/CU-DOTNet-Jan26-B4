using System;

namespace Week08Assessment.Library
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }

        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary <= 0)
                    return 0m;

                if (AttendancePercentage < 0 || AttendancePercentage > 100)
                    throw new InvalidOperationException("Invalid attendance percentage.");

                decimal bonusPercentage = PerformanceRating switch
                {
                    5 => 0.25m,
                    4 => 0.18m,
                    3 => 0.12m,
                    2 => 0.05m,
                    1 => 0.00m,
                    _=> throw new InvalidOperationException("Invalid Performance Rating")
                };

                //bonus of experience
                decimal bonus = BaseSalary * bonusPercentage;
                if (YearsOfExperience > 10)
                    bonus += BaseSalary * 0.05m;
                else if (YearsOfExperience > 5)
                    bonus += BaseSalary * 0.03m;

                //attendance
                if (AttendancePercentage < 85)
                    bonus *= 0.80m;

                bonus *= DepartmentMultiplier;

                decimal maxBonus = BaseSalary * 0.40m;
                if (bonus > maxBonus)
                    bonus = maxBonus;

                decimal taxRate;

                if (bonus <= 150000)
                    taxRate = 0.10m;
                else if (bonus <= 300000)
                    taxRate = 0.20m;
                else
                    taxRate = 0.30m;

                decimal finalBonus = bonus - (bonus * taxRate);

                return(finalBonus);
            }
        }
    }
}

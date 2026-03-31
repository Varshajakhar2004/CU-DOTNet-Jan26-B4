using NUnit.Framework;
using System;
using Week08Assessment.Library;

namespace Week08Assessment.Tests
{
    public class EmployeeBonusTests
    {
        private EmployeeBonus CreateEmployee(
            decimal salary,
            int performancerating,
            int yearofexperience,
            decimal departmentmultiplier,
            double attendance)
        {
            return new EmployeeBonus
            {
                BaseSalary = salary,
                PerformanceRating = performancerating,
                YearsOfExperience = yearofexperience,
                DepartmentMultiplier = departmentmultiplier,
                AttendancePercentage = attendance
            };
        }

        [Test]
        public void NormalCase()
        {
            var emp = CreateEmployee(500000, 5, 6, 1.1m, 95);
            Assert.AreEqual(123200m, emp.NetAnnualBonus);
        }

        [Test]
        public void AttendancePenalty()
        {
            var emp = CreateEmployee(400000, 4, 8, 1.0m, 80);
            Assert.AreEqual(60480m, emp.NetAnnualBonus);
        }

        [Test]
        public void CapRule()
        {
            var emp = CreateEmployee(1000000, 5, 15, 1.5m, 95);
            Assert.AreEqual(280000m, emp.NetAnnualBonus);
        }

        [Test]
        public void ZeroSalary()
        {
            var emp = CreateEmployee(0, 5, 10, 1.0m, 100);
            Assert.AreEqual(0m, emp.NetAnnualBonus);
        }

        [Test]
        public void LowRating()
        {
            var emp = CreateEmployee(300000, 2, 3, 1.0m, 90);
            Assert.AreEqual(13500m, emp.NetAnnualBonus);
        }

        [Test]
        public void TaxBoundary()
        {
            var emp = CreateEmployee(600000, 3, 0, 1.0m, 100);
            Assert.AreEqual(64800m, emp.NetAnnualBonus);
        }

        [Test]
        public void HighTaxSlab()
        {
            var emp = CreateEmployee(900000, 5, 11, 1.2m, 100);
            Assert.AreEqual(226800m, emp.NetAnnualBonus);
        }

        [Test]
        public void RoundingTest()
        {
            var emp = CreateEmployee(555555, 4, 6, 1.13m, 92);
            Assert.AreEqual(118649.88135m, emp.NetAnnualBonus);
        }

        [Test]
        public void InvalidRating()
        {
            var emp = CreateEmployee(500000, 6, 5, 1.0m, 90);

            Assert.Throws<InvalidOperationException>(() =>
            {
                var result = emp.NetAnnualBonus;
            });
        }
    }
}
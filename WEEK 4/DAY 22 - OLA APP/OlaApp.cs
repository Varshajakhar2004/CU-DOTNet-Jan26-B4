using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace week_4
{
    public class Ride
    {
        public int RideId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Fare { get; set; }

        public  Ride(int rideId, string from, string to, int fare)
        {
            RideId = rideId;
            From = from;
            To = to;
            Fare = fare;
        }
    }


    public class OlaDriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNo { get; set; }


        public List<Ride> RideList { get; set; } = new List<Ride>();
        public double TotalFare()
        {
            double total = 0;
            foreach (var ride in RideList)
            {
                total += ride.Fare;
            }
            return total;
        }

        public void DisplayRides()
        {
            Console.WriteLine($"Driver id - {Id}, Driver Name -{Name}, Vehicle Number - {VehicleNo}");
            if(RideList.Count ==0)
            {
                Console.WriteLine("No ride till now");
                return;
            }
            Console.WriteLine("Driver Rides");
            foreach (var ride in RideList)
            {
                Console.WriteLine($"Ride Id - {ride.RideId},Pickup From- {ride.From}, Drop At-{ride.To}, Fare for the ride -{ride.Fare} ");
            }
            Console.WriteLine($"Total Fare : {TotalFare()}");
            Console.WriteLine(new string('-',40));


        }

        public OlaDriver(int id, string name, string vehicleNo)
        {
            Id = id;
            Name = name;
            VehicleNo = vehicleNo;
        }
    }

    internal class OlaApp
    {
        static void Main(string[] args)
        {
            var drivers = new List<OlaDriver>();

            OlaDriver driver1 = new OlaDriver(1, "ABCD", "DL01AB1234");
            driver1.RideList.Add(new Ride(101, "Airport", "Hotel", 500));
            driver1.RideList.Add(new Ride(102, "Hotel", "Market", 200));

            OlaDriver driver2 = new OlaDriver(2, "XYZA", "DL02XY5678");
            driver2.RideList.Add(new Ride(201, "College", "bus stop", 300));
            driver2.RideList.Add(new Ride(202, "Mall", "Home", 150));
            driver2.RideList.Add(new Ride(203, "Home", "Office", 250));
            driver2.RideList.Add(new Ride(205, "Airport", "Office", 850));


            drivers.Add(driver1);
            drivers.Add(driver2);

            foreach (var driver in drivers)
            {
                driver.DisplayRides();
            }
            Console.ReadLine();
        }
    }
}

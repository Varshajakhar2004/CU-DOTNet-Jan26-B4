using Microsoft.VisualBasic;

namespace week_4
{

    class Flight : IComparable<Flight>
    {
        public string FlightNumber{ get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight other)
        {
            return this.Price.CompareTo(other?.Price);
        }

        public override string ToString()
        {
            return $"{FlightNumber}| Price :{Price:c}| Duration : {Duration}|Departure :{DepartureTime :yyyy-MM-dd HH:mm}";
        }

        public class DurationSorted : IComparer<Flight>
        {
            public int Compare(Flight? x, Flight? y)
            {
                return x.Duration.CompareTo(y?.Duration);
            }
        }

        public class DepartureTimeSorted : IComparer<Flight>
        {
            public int Compare(Flight? x, Flight? y)
            {
                return x.DepartureTime.CompareTo(y.DepartureTime);
            }
        }
    }
    internal class SkyHighFlightAggregator
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
            {
                new Flight(){FlightNumber ="AR00312", Price = 4589, Duration = TimeSpan.FromHours(2), DepartureTime=DateTime.Today.AddHours(9)},
                new Flight(){FlightNumber ="ST00512", Price = 10963, Duration = TimeSpan.FromHours(8), DepartureTime=DateTime.Today.AddHours(4)},
                new Flight(){FlightNumber ="CR00098", Price = 2875, Duration = TimeSpan.FromHours(4), DepartureTime=DateTime.Today.AddHours(5)},
                new Flight(){FlightNumber ="SV00842", Price = 8976, Duration = TimeSpan.FromHours(10), DepartureTime=DateTime.Today.AddHours(7)},

            };
            flights.Sort();
            Console.WriteLine("Economy View");
            flights.ForEach(f => Console.WriteLine(f.FlightNumber));

            flights.Sort(new Flight.DurationSorted());
            Console.WriteLine("Business Runner View");
            flights.ForEach(f => Console.WriteLine(f.FlightNumber));

            flights.Sort(new Flight.DepartureTimeSorted());
            Console.WriteLine("Early Bird View");
            flights.ForEach(f => Console.WriteLine(f.FlightNumber));
        }
    }
        
    
}

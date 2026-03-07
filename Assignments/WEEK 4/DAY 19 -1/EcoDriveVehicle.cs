using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace week_4
{ 
    abstract class Vehicle
    {
        public string ModelName { get; set; }

        public Vehicle(string modelName)
        {
            ModelName = modelName;
        }

        public abstract void Move();

        public virtual string GetFuelStatus()
        {
            return "Fuel level is stable";
        }
    }

    class ElectricCar : Vehicle
    {
        public ElectricCar(string ModelName) : base(ModelName)
        {

        }

        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power");
        }

        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%";
        }
    }

    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string ModelName) : base(ModelName)
        {

        }

        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high torque diesel power");
        }
    }

    class CargoPlane : Vehicle
    {
        public CargoPlane(string ModelName) : base(ModelName)
        {

        }

        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
        }

        public override string GetFuelStatus()
        {
            string basestatus = base.GetFuelStatus();
            return basestatus + " Checking jet fuel reserves";
        }
    }
    internal class EcoDriveVehicle
    {
        static void Main(string[] args)
        {
            Vehicle[] fleet = new Vehicle[]
            {
                new ElectricCar("Tesla"),
                new HeavyTruck("Volvo"),
                new CargoPlane("AirJet")
            };

            foreach (Vehicle vehicle in fleet)
            {
                vehicle.Move();
                Console.WriteLine(vehicle.GetFuelStatus());
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

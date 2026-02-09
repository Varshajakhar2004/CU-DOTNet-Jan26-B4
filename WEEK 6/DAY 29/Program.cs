namespace WEEK_6
{
    interface ITimer
    {
        void SetTimer(int minutes);
    }

    interface ISmart
    {
        void ConnectWifi();
    }

    abstract class KitchenElectronicAppliances
    {
        public int ElecticWalts { get; set; }
        public string ModelName { get; set; }
        public double Price { get; set; }
        public abstract void Cook();

        public virtual void PreHeat()
        {
            Console.WriteLine("Requires no preheat");
        }
    }

    class MicroWave : KitchenElectronicAppliances, ITimer
    {
        public override void Cook()
        {
            Console.WriteLine("Cooking food using Microwave");
        }
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"Timer set for cooking:{minutes}minutes");
        }
    }


    class ElectricOven : KitchenElectronicAppliances, ISmart , ITimer
    {
        public override void PreHeat()
        {
            Console.WriteLine("Oven is preheating");
        }
        public override void Cook()
        {
            PreHeat();
            Console.WriteLine("Cooking food using ElectricOven");
        }
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"Timer set for cooking:{minutes} minutes");
        }

        public void ConnectWifi()
        {
            Console.WriteLine("Wifi connected");
        }

    }


    class AirFryer : KitchenElectronicAppliances, ITimer
    {
        public override void Cook()
        {
            Console.WriteLine("Cooking food using airfryer");
        }
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"Timer set for cooking:{minutes}minutes");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<KitchenElectronicAppliances> appliances = new List<KitchenElectronicAppliances>
            {
            new MicroWave{ ModelName = "MW-100", ElecticWalts = 800, Price = 15000 },
            new ElectricOven { ModelName = "OV-500", ElecticWalts = 2000, Price = 9000 },
            new AirFryer { ModelName = "AF-300", ElecticWalts = 1500, Price = 5000 }
            };

            foreach (var appliance in appliances)
            {
                Console.WriteLine($"{appliance.ModelName}");
                appliance.Cook();

                if (appliance is ITimer )
                {
                    ITimer timerDevice = (ITimer)appliance;
                    Console.WriteLine("Enter the timer ");
                    int minutes = int.Parse(Console.ReadLine());
                    timerDevice.SetTimer(minutes);
                }


                if (appliance is ISmart )
                {
                    ISmart wifiDevice = (ISmart)appliance;
                    wifiDevice.ConnectWifi();
                }

            }

        }
    }
}

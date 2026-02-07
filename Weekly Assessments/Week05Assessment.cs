namespace Week_5
{
    interface ILoggable
    {
        void SaveLog(string message);
    }

    class ILogManager : ILoggable
    {
        public void SaveLog(string message)
        {
            using (StreamWriter sw = new StreamWriter(@"../../../shipment_audit.log", true))
            {
                sw.WriteLine($"{message}");
            }
        }
    }

    class RestrictedDestinationException : Exception
    {
        public string DeniedLocation { get; set; }

         public  RestrictedDestinationException(string location) : base($"Restricted loaction is detected :{location}")
         {
            DeniedLocation = location;
         }

    }

    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string id) : base($"{id} has Invalid packaging")
        {

        }
    }

    abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination  { get; set; }

        public abstract void ProcessShipment();

        protected static List<string> DeniedLocation = new List<string> { "North Pole", "Unknown Island" };
    }

    class ExpressShipment : Shipment
    {
        public bool Fragile { get; set; }
        public bool Reinforce { get; set; }

        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException("Wight can not be zero");

            if (DeniedLocation.Contains(Destination))
                throw new RestrictedDestinationException(Destination);

            if (Fragile && !Reinforce)
                throw new InsecurePackagingException(TrackingId);

            Console.WriteLine($"Express shipment of {TrackingId} is completed");
        }
    }
    

    class HeavyFreight : Shipment
    {
        public bool HeavyLiftPermit { get; set; }

        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException("Wight can not be zero");

            if (DeniedLocation.Contains(Destination))
                throw new RestrictedDestinationException(Destination);

            if (Weight > 1000 && !HeavyLiftPermit)
                throw new Exception("Shipment requires heavy lift permit to process further");

            Console.WriteLine($"Heavy Freight shipment of {TrackingId} is completed");
        }
    }


    internal class Week05Assessement
    {
        static void Main(string[] args)
        {
            ILoggable logger = new ILogManager();
            List<Shipment> shipments = new List<Shipment>();
            {
                shipments.Add(new ExpressShipment
                {
                    TrackingId = "ES1015",
                    Weight = 70,
                    Destination = "Chandigarh sector 2",
                    Fragile = true,
                    Reinforce = false
                });
                shipments.Add(new HeavyFreight
                {
                    TrackingId = "HF001",
                    Weight = 1500,
                    Destination = "Mumbai sector 68",
                    HeavyLiftPermit = false
                });

                shipments.Add(new HeavyFreight
                {
                    TrackingId = "HF901",
                    Weight = 1104,
                    Destination = "Delhi",
                    HeavyLiftPermit = false
                });

                shipments.Add(new ExpressShipment
                {
                    TrackingId = "ES1043",
                    Weight = 20,
                    Destination = "North Pole",
                    Fragile = false,
                    Reinforce = false
                });

                shipments.Add(new ExpressShipment
                {
                    TrackingId = "ES2015",
                    Weight = 79,
                    Destination = "Mohali",
                    Fragile = true,
                    Reinforce = true
                });
                shipments.Add(new ExpressShipment
                {
                    TrackingId = "ES2019",
                    Weight = 79,
                    Destination = "Mohali",
                    Fragile = true,
                    Reinforce = false
                });
            }
            ;

            foreach (Shipment shipment in shipments)
            {
                try
                {
                    shipment.ProcessShipment();
                    logger.SaveLog($"SUCCESS: Shipment {shipment.TrackingId} processed.");
                }
                catch (RestrictedDestinationException ex)
                {
                    logger.SaveLog($"SECURITY ALERT: {ex.Message} | Location: {ex.DeniedLocation}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    logger.SaveLog($"DATA ENTRY ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    logger.SaveLog($"GENERAL ERROR: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"Processing attempt finished for ID: {shipment.TrackingId}");
                }
            }

            Console.WriteLine("All shipments done");

        }
    }
}

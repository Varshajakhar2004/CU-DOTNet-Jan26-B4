using System;
using System.Collections.Generic;

namespace Week09
{
    public class Item   
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Weight { get; set; }

        public Item(string name, string category, double weight)
        {
            Name = name;
            Category = category;
            Weight = weight;
        }
    }

    public class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items { get; set; }

        public Container(string containerID, List<Item> items)
        {
            ContainerID = containerID;
            Items = items ?? new List<Item>();
        }
    }

    public class CargoHelper
    {
        public static List<string> FindHeavy(List<List<Container>> cargoBay, double limit)
        {
            List<string> heavyContainers = new List<string>();

            foreach (var row in cargoBay)               
            {
                foreach (var container in row)
                {
                    double total = 0;

                    foreach (var item in container.Items)
                    {
                        total += item.Weight;
                    }

                    if (total > limit)
                        heavyContainers.Add(container.ContainerID);
                }
            }

            return heavyContainers;
        }

        public static Dictionary<string, int> CountCategories(List<List<Container>> cargoBay)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var row in cargoBay)
            {
                foreach (var container in row)
                {
                    foreach (var item in container.Items)
                    {
                        if (result.ContainsKey(item.Category))
                            result[item.Category]++;
                        else
                            result[item.Category] = 1;
                    }
                }
            }

            return result;
        }

        public static List<Item> FlattenAndSort(List<List<Container>> cargoBay)
        {
            List<Item> items = new List<Item>();

            foreach (var row in cargoBay)
            {
                foreach (var container in row)
                {
                    foreach (var item in container.Items)
                    {
                        bool exists = false;

                        foreach (var i in items)
                        {
                            if (i.Name == item.Name)
                            {
                                exists = true;
                                break;
                            }
                        }

                        if (!exists)
                            items.Add(item);
                    }
                }
            }

            items.Sort((a, b) =>
            {
                if (a.Category == b.Category)
                    return b.Weight.CompareTo(a.Weight);
                return a.Category.CompareTo(b.Category);
            });

            return items;
        }
    }

    internal class Cargo
    {
        static void Main(string[] args)
        {
            var cargoBay = new List<List<Container>>
            {
                new List<Container>
                {
                    new Container("C001", new List<Item>
                    {
                        new Item("Laptop", "Tech", 2.5),
                        new Item("Monitor", "Tech", 5.0)
                    }),
                    new Container("C104", new List<Item>
                    {
                        new Item("Server Rack", "Tech", 45.0)
                    })
                }
            };

            //task a
            var heavy = CargoHelper.FindHeavy(cargoBay, 10);
            Console.WriteLine("Heavy Containers:");
            foreach (var id in heavy)
            {
                Console.WriteLine(id);
            }
            //task b
            var categories = CargoHelper.CountCategories(cargoBay);
            Console.WriteLine("\nCategory Counts:");
            foreach (var c in categories)
            {
                Console.WriteLine(c.Key + " : " + c.Value);
            }
            //task c
            var finalItems = CargoHelper.FlattenAndSort(cargoBay);
            Console.WriteLine("\nFinal Sorted Items:");
            foreach (var item in finalItems)
            {
                Console.WriteLine(item.Category + " - " + item.Name + " - " + item.Weight);
            }
        }
    }
}
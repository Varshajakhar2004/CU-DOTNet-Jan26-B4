using System;
using System.Collections.Generic;
using System.Linq;

namespace Week_6_Linq_Full_Set
{
    class Student { public int Id; public string Name; public string Class; public int Marks; }
    class Employee { public int Id; public string Name; public string Dept; public double Salary; public DateTime JoinDate; }
    class Product { public int Id; public string Name; public string Category; public double Price; }
    class Sale { public int ProductId; public int Qty; }
    class Book { public string Title; public string Author; public string Genre; public int Year; public double Price; }
    class Customer { public int Id; public string Name; public string City; }
    class Order { public int OrderId; public int CustomerId; public double Amount; }
    class Movie { public string Title; public string Genre; public double Rating; public int Year; }
    class Transaction { public int Acc; public double Amount; public string Type; }
    class CartItem { public string Name; public string Category; public double Price; public int Qty; }
    class User { public int Id; public string Name; public string Country; }
    class Post { public int UserId; public int Likes; }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //  STUDENT PERFORMANCE ANALYTICS

            var students = new List<Student>
            {
                new Student{Id=1, Name="Amit", Class="10A", Marks=85},
                new Student{Id=2, Name="Neha", Class="10A", Marks=72},
                new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
                new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
                new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };

            Console.WriteLine("------------STUDENT PERFORMANCE-----------------");

            var top3 = students.OrderByDescending(s => s.Marks).Take(3);
            Console.WriteLine("Top 3 Students:");
            foreach (var s in top3)
                Console.WriteLine($"{s.Name} - {s.Marks}");

            var avgClass = students.GroupBy(s => s.Class)
                                   .Select(g => new
                                   {
                                       Class = g.Key,
                                       AvgMarks = g.Average(x => x.Marks)
                                   });

            Console.WriteLine("\nAverage Marks Per Class:");
            foreach (var c in avgClass)
                Console.WriteLine($"{c.Class} - {c.AvgMarks}");

            var belowAvg = students.GroupBy(s => s.Class)
                                   .SelectMany(g =>
                                   {
                                       double avg = g.Average(x => x.Marks);
                                       return g.Where(x => x.Marks < avg);
                                   });

            Console.WriteLine("\nStudents Below Class Average:");
            foreach (var s in belowAvg)
                Console.WriteLine($"{s.Name}");

            var orderedStudents = students.OrderBy(s => s.Class)
                                          .ThenByDescending(s => s.Marks);

            Console.WriteLine("\nOrdered Students:");
            foreach (var s in orderedStudents)
                Console.WriteLine($"{s.Class} - {s.Name} - {s.Marks}");

            // EMPLOYEE SALARY PROCESSING
            var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
                new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
                new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
                new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
            };

            Console.WriteLine("\n---------------EMPLOYEE SALARY -----------");

            var salaryStats = employees.GroupBy(e => e.Dept)
                                       .Select(g => new
                                       {
                                           Dept = g.Key,
                                           MaxSalary = g.Max(x => x.Salary),
                                           MinSalary = g.Min(x => x.Salary),
                                           Count = g.Count()
                                       });

            foreach (var s in salaryStats)
                Console.WriteLine($"{s.Dept} - Max:{s.MaxSalary}, Min:{s.MinSalary}, Count:{s.Count}");

            var joinedAfter2020 = employees.Where(e => e.JoinDate.Year > 2020);
            Console.WriteLine("\nJoined After 2020:");
            foreach (var e in joinedAfter2020)
                Console.WriteLine(e.Name);

            var annualSalary = employees.Select(e => new
            {
                e.Name,
                AnnualSalary = e.Salary * 12
            });

            Console.WriteLine("\nAnnual Salary:");
            foreach (var e in annualSalary)
                Console.WriteLine($"{e.Name} - {e.AnnualSalary}");

            // PRODUCT INVENTORY & SALES

            var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
                new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
                new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };

            var sales = new List<Sale>
            {
                new Sale{ProductId=1, Qty=10},
                new Sale{ProductId=2, Qty=20}
            };

            Console.WriteLine("\n----------PRODUCT SALES------------------");

            var revenue = products.GroupJoin(sales,
                p => p.Id,
                s => s.ProductId,
                (p, s) => new
                {
                    p.Name,
                    Revenue = s.Sum(x => x.Qty) * p.Price
                });

            foreach (var r in revenue)
                Console.WriteLine($"{r.Name} - {r.Revenue}");

            var zeroSales = products.GroupJoin(sales,
                p => p.Id,
                s => s.ProductId,
                (p, s) => new { p.Name, HasSales = s.Any() })
                .Where(x => !x.HasSales);

            Console.WriteLine("Products With Zero Sales:");
            foreach (var p in zeroSales)
                Console.WriteLine(p.Name);

            
            // LIBRARY MANAGEMENT

            var books = new List<Book>
            {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
            };

            Console.WriteLine("\n-------------LIBRARY--------------------");

            var recentBooks = books.Where(b => b.Year > 2015);
            foreach (var b in recentBooks)
                Console.WriteLine(b.Title);

            var expensivePerGenre = books.GroupBy(b => b.Genre)
                                          .Select(g => g.OrderByDescending(b => b.Price).First());

            Console.WriteLine("Most Expensive Per Genre:");
            foreach (var b in expensivePerGenre)
                Console.WriteLine($"{b.Genre} - {b.Title}");

            var booksByGenre = books.GroupBy(b => b.Genre)
                        .Select(g => new
                        {
                            Genre = g.Key,
                            Count = g.Count()
                        });

            Console.WriteLine("\nBooks Count Per Genre:");
            foreach (var g in booksByGenre)
                Console.WriteLine($"{g.Genre} - {g.Count}");

            var distinctAuthors = books.Select(b => b.Author).Distinct();

            Console.WriteLine("\nDistinct Authors:");
            foreach (var author in distinctAuthors)
                Console.WriteLine(author);


            //  CUSTOMER ORDERS

            var customers = new List<Customer>
            {
                new Customer{Id=1, Name="Ajay", City="Delhi"},
                new Customer{Id=2, Name="Sunita", City="Mumbai"}
            };

            var orders = new List<Order>
            {
                new Order{OrderId=1, CustomerId=1, Amount=20000},
                new Order{OrderId=2, CustomerId=1, Amount=40000}
            };



            Console.WriteLine("\n----------------CUSTOMER ORDERS------------------");

            var totalPerCustomer = customers.GroupJoin(orders,
                c => c.Id,
                o => o.CustomerId,
                (c, o) => new { c.Name, Total = o.Sum(x => x.Amount) });

            foreach (var c in totalPerCustomer)
                Console.WriteLine($"{c.Name} - {c.Total}");

            var customersWithNoOrders = customers.GroupJoin(orders,c => c.Id,o => o.CustomerId,(c, o) => new { c.Name, HasOrders = o.Any() }).Where(x => !x.HasOrders);

            Console.WriteLine("\nCustomers With No Orders:");
            foreach (var c in customersWithNoOrders)
                Console.WriteLine(c.Name);

            var customersAbove50k = customers.GroupJoin(orders,
                c => c.Id,
                o => o.CustomerId,
                (c, o) => new { c.Name, Total = o.Sum(x => x.Amount) })
                .Where(x => x.Total > 50000);

            Console.WriteLine("\nCustomers Spending Above 50000:");
            foreach (var c in customersAbove50k)
                Console.WriteLine(c.Name);

            var sortedCustomers = customers.GroupJoin(orders,
                c => c.Id,
                o => o.CustomerId,
                (c, o) => new { c.Name, Total = o.Sum(x => x.Amount) })
                .OrderByDescending(x => x.Total);

            Console.WriteLine("\nCustomers Sorted By Spending:");
            foreach (var c in sortedCustomers)
                Console.WriteLine($"{c.Name} - {c.Total}");


            //  MOVIES

            var movies = new List<Movie>
            {
                new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
                new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
                new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
            };

            Console.WriteLine("\n---------------MOVIES-------------------------");

            var highRated = movies.Where(m => m.Rating > 8);
            foreach (var m in highRated)
                Console.WriteLine(m.Title);

            var avgRating = movies.GroupBy(m => m.Genre)
                                  .Select(g => new { Genre = g.Key, Avg = g.Average(x => x.Rating) });

            foreach (var a in avgRating)
                Console.WriteLine($"{a.Genre} - {a.Avg}");

            var latestPerGenre = movies.GroupBy(m => m.Genre)
                           .Select(g => g.OrderByDescending(m => m.Year).First());

            Console.WriteLine("\nLatest Movie Per Genre:");
            foreach (var m in latestPerGenre)
                Console.WriteLine($"{m.Genre} - {m.Title}");

            var top5Movies = movies.OrderByDescending(m => m.Rating).Take(5);

            Console.WriteLine("\nTop 5 Highest Rated Movies:");
            foreach (var m in top5Movies)
                Console.WriteLine($"{m.Title} - {m.Rating}");


            //  BANK TRANSACTIONS

            var transactions = new List<Transaction>
            {
                new Transaction{Acc=101, Amount=5000, Type="Credit"},
                new Transaction{Acc=101, Amount=2000, Type="Debit"},
                new Transaction{Acc=102, Amount=10000, Type="Debit"}
            };

            Console.WriteLine("\n-----------------BANK------------------------");

            var balance = transactions.GroupBy(t => t.Acc)
                                      .Select(g => new
                                      {
                                          Acc = g.Key,
                                          Balance = g.Sum(t => t.Type == "Credit" ? t.Amount : -t.Amount)
                                      });

            foreach (var b in balance)
                Console.WriteLine($"{b.Acc} - {b.Balance}");

            var suspiciousAccounts = transactions.GroupBy(t => t.Acc) .Where(g => g.Where(x => x.Type == "Debit").Sum(x => x.Amount) >
                g.Where(x => x.Type == "Credit").Sum(x => x.Amount)) .Select(g => g.Key);

            Console.WriteLine("\nSuspicious Accounts (Debit > Credit):");
            foreach (var acc in suspiciousAccounts)
                Console.WriteLine(acc);

            var highestTransaction = transactions.GroupBy(t => t.Acc)
                .Select(g => new
                {
                    Acc = g.Key,
                    MaxAmount = g.Max(x => x.Amount)
                });

            Console.WriteLine("\nHighest Transaction Per Account:");
            foreach (var h in highestTransaction)
                Console.WriteLine($"{h.Acc} - {h.MaxAmount}");



            var cart = new List<CartItem>
            {
                new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
                new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
            };

            Console.WriteLine("\n----------------CART--------------------");
            Console.WriteLine("Total Cart Value: " + cart.Sum(c => c.Price * c.Qty));
            var categoryCost = cart.GroupBy(c => c.Category)
                       .Select(g => new
                       {
                           Category = g.Key,
                           Total = g.Sum(x => x.Price * x.Qty)
                       });

            Console.WriteLine("\nCategory Wise Cost:");
            foreach (var c in categoryCost)
                Console.WriteLine($"{c.Category} - {c.Total}");

            var discountedCart = cart.Select(c => new
            {
                c.Name,
                FinalPrice = c.Category == "Electronics"
                    ? c.Price * 0.9
                    : c.Price
            });

            Console.WriteLine("\nCart After 10% Discount On Electronics:");
            foreach (var item in discountedCart)
                Console.WriteLine($"{item.Name} - {item.FinalPrice}");

            var cartSummary = cart.Select(c => new
            {
                c.Name,
                c.Category,
                Total = c.Price * c.Qty
            });

            Console.WriteLine("\nCart Summary:");
            foreach (var item in cartSummary)
                Console.WriteLine($"{item.Name} - {item.Total}");


            //SOCIAL MEDIA

            var users = new List<User>
            {
                new User{Id=1, Name="A", Country="India"},
                new User{Id=2, Name="B", Country="USA"}
            };

            var posts = new List<Post>
            {
                new Post{UserId=1, Likes=100},
                new Post{UserId=1, Likes=50}
            };

            Console.WriteLine("\n--------------SOCIAL MEDIA ---------------------");

            var avgLikes = posts.Average(p => p.Likes);
            Console.WriteLine("Average Likes Per Post: " + avgLikes);
            var topUsers = users.GroupJoin(posts,u => u.Id,p => p.UserId,(u, p) => new { u.Name,TotalLikes = p.Sum(x => x.Likes)})
                                             .OrderByDescending(x => x.TotalLikes);

            Console.WriteLine("\nTop Users By Total Likes:");
            foreach (var u in topUsers)
                Console.WriteLine($"{u.Name} - {u.TotalLikes}");

            var usersByCountry = users.GroupBy(u => u.Country);

            Console.WriteLine("\nUsers Grouped By Country:");
            foreach (var group in usersByCountry)
            {
                Console.WriteLine(group.Key);
                foreach (var u in group)
                    Console.WriteLine("  " + u.Name);
            }

            var inactiveUsers = users.GroupJoin(posts,
                u => u.Id,
                p => p.UserId,
                (u, p) => new { u.Name, HasPosts = p.Any() })
                .Where(x => !x.HasPosts);

            Console.WriteLine("\nInactive Users (No Posts):");
            foreach (var u in inactiveUsers)
                Console.WriteLine(u.Name);


            Console.ReadLine();
        }
    }
}

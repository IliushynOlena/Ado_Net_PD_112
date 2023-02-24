using _07_EF_example.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _07_EF_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplanesDbContext context = new AirplanesDbContext();

            //context.Clients.Add(new Client()
            //{
            //    Name = "Volodia",
            //    Birthday = new DateTime(2002, 7, 12),
            //    Email = "volodia@gmail.com"
            //});

            //context.SaveChanges();

            //foreach (var c in context.Clients)
            //{
            //    Console.WriteLine($"Client {c.Id }  {c.Name}  {c.Birthday}");
            //}

            var filterCollec = context.Flights
                .Include(f=>f.Airplane).//Like Join in SQL
                Include(f=>f.Clients).
                OrderBy(f => f.ArrivalTime);
                //.Where(f => f.ArrivalCity == "Lviv").

            foreach (var f in filterCollec)
            {
                Console.WriteLine($"Flight {f.Number}  {f.ArrivalCity}  {f.DepartureCity}" +
                    $"- airplane {f.Airplane?.Model} " +
                    $" - with {f.Clients?.Count}");
                foreach (var c in f.Clients)
                {
                    Console.WriteLine($" {c.Name}   {c.Email }");
                }
            }

            var client = context.Clients.Find(2);
            //Explicit data loading : Context.Entry(entity).Collection/Reference.Load();
            context.Entry(client).Collection(c=>c.Flights).Load();  
            Console.WriteLine($" {client.Name}  {client.Flights?.Count} fligths" );




            //if(client != null)
            //{
            //    context.Clients.Remove(client);
            //    context.SaveChanges();
            //}
            //foreach (var c in context.Clients)
            //{
            //    Console.WriteLine($"Client {c.Id}  {c.Name}  {c.Birthday}");
            //}


        }
    }
}

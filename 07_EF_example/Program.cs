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
                .Include(f => f.Airplane).//Like Join in SQL
                 Include(f => f.ClientFligth);
                 //.OrderBy(f => f.ArrivalTime);
            //.Where(f => f.ArrivalCity == "Lviv").

            //foreach (var f in filterCollec)
            //{
            //    context.Entry(f).Collection(x => x.ClientFligth).Load();
            //    Console.WriteLine($"Flight {f.Number}  {f.ArrivalCity}  {f.DepartureCity}" +
            //        $"- airplane {f.Airplane?.Model} " +
            //        $" - with {f.ClientFligth?.Count}");
            //    foreach (var c in f.ClientFligth)
            //    {
            //        Console.WriteLine($" {c.ClientId}  Email :  {c.Client?.Email}  ");
            //    }
            //}

                var client = context.Clients.Find(1);
                ////Explicit data loading : Context.Entry(entity).Collection/Reference.Load();
                context.Entry(client).Collection(c=>c.ClientFligth).Load();  
                Console.WriteLine($" {client.Name}  {client.ClientFligth?.Count} fligths" );
            foreach (var c in client.ClientFligth)
            {
                Console.WriteLine($" {c.Flight?.Number }  {c.Flight?.ArrivalCity} {c.Flight?.DepartureCity}" );
            }




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

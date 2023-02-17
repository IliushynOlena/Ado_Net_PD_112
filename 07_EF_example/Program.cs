using System;
using System.Linq;

namespace _07_EF_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplanesDbContext context = new AirplanesDbContext();

            context.Clients.Add(new Client()
            {
                Name = "Volodia",
                Birthday = new DateTime(2002, 7, 12),
                Email = "volodia@gmail.com"
            });

            context.SaveChanges();

            foreach (var c in context.Clients)
            {
                Console.WriteLine($"Client {c.Id }  {c.Name}  {c.Birthday}");
            }

            var filterCollec = context.Flights
                .Where(f => f.ArrivalCity == "Lviv").
                OrderBy(f => f.ArrivalTime);

            foreach (var f in filterCollec)
            {
                Console.WriteLine($"Flight {f.Number}  {f.ArrivalCity}  {f.DepartureTime}");
            }


            var client = context.Clients.Find(1);

            if(client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }
            foreach (var c in context.Clients)
            {
                Console.WriteLine($"Client {c.Id}  {c.Name}  {c.Birthday}");
            }


        }
    }
}

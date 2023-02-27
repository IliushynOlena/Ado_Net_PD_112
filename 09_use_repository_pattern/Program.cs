using _07_EF_example;
using _07_EF_example.Entities;
using data_access_entity.Repositories;
using System;

namespace _09_use_repository_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Flight> repository = new Repository<Flight>(new AirplanesDbContext());

            foreach (var f in repository.GetAll())
            {
                //context.Entry(f).Collection(x => x.ClientFligth).Load();
                Console.WriteLine($"Flight {f.Number}  {f.ArrivalCity}  {f.DepartureCity}" +
                    $"- airplane {f.Airplane?.Model} " +
                    $" - with {f.ClientFligth?.Count}");
                //foreach (var c in f.ClientFligth)
                //{
                //    Console.WriteLine($" {c.ClientId}  {c.Client?.Name}  ");
                //}
            }

            }
    }
}

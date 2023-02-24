using _07_EF_example.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _07_EF_example.Helpers
{
    internal static class DbInitializer
    {
        //public static void SeedClientsFligth(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Client>()
        //   .HasMany(c => c.Flights)
        //   .WithMany(f => f.Clients)
        //   .UsingEntity<Dictionary<object, object>>(
        //       "PostTag",

        //       r => r.HasOne<Id>().WithMany().HasForeignKey("TagId"),
        //       l => l.HasOne<Post>().WithMany().HasForeignKey("PostId"),
        //       je =>
        //       {
        //           je.HasKey("PostId", "TagId");
        //           je.HasData(
        //               new { PostId = 1, TagId = "general" },
        //               new { PostId = 1, TagId = "informative" },
        //               new { PostId = 2, TagId = "classic" },
        //               new { PostId = 3, TagId = "opinion" },
        //               new { PostId = 4, TagId = "opinion" },
        //               new { PostId = 4, TagId = "informative" });
        //       });
        //}
        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                new Airplane()
                {
                    Id = 1,
                    Model = "Antonov 125",
                    MaxPassangers = 1200
                },
                new Airplane()
                {
                    Id = 2,
                    Model = "Boeing 747",
                    MaxPassangers = 1300
                }
            });

        }
        public static void SeedFligths(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]
        {
                new Flight()
                {
                    Number = 1,
                    AirplaneId = 1,
                    ArrivalCity = "Lviv",
                    DepartureCity = "Kyiv",
                    DepartureTime = new DateTime(2023,3,12),
                    ArrivalTime = new DateTime(2023,3,12)

                },
                new Flight()
                {
                    Number = 2,
                    AirplaneId = 2,
                    ArrivalCity = "Lviv",
                    DepartureCity = "Warsaw",
                    DepartureTime = new DateTime(2023,5,12),
                    ArrivalTime = new DateTime(2023,5,12)

                }
            });
         
        }
    }
}

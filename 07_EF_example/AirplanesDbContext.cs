using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _07_EF_example
{
    internal class AirplanesDbContext : DbContext
    {
        public AirplanesDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        //Collections
        //Aiplanes
        //Clients
        //Flights
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                                        Initial Catalog = SuperAirplaneDb;
                                        Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                        TrustServerCertificate=False;
                                        ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Initializer
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
    //Entities
    [Table("Passengers")]
    class Client
    {
        //Primary Key naming : Id/id/ID / EntityName + Id
        public int Id { get; set; }
        [Required]//not null
        [MaxLength(100)]//nvarchar(100)
        [Column("FirstName")]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
    class Flight
    {
        [Key]//set primary key
        public int Number{ get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        /////Relationship type : one to many
        ///Foreign key namig : RelatingEntityName + RelatingEntityPrimaryKeyName
        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
    class Airplane
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Model { get; set; }
        public int MaxPassangers { get; set; }
        public ICollection<Flight> Flights { get; set; }

    }
}

using _07_EF_example.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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
                                        Initial Catalog = SuperAirplaneDbWithMigration;
                                        Integrated Security=True;Connect Timeout=2;Encrypt=False;
                                        TrustServerCertificate=False;
                                        ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Initializer - Seeder
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
            //Fluent API configuratuins
            modelBuilder.Entity<Airplane>().Property(a => a.Model).
                HasMaxLength(100).
                IsRequired();

            modelBuilder.Entity<Client>().ToTable("Passengers");
            modelBuilder.Entity<Client>().Property(c => c.Name).
                HasMaxLength(100).
                IsRequired().
                HasColumnName("FirstName");
            modelBuilder.Entity<Client>().Property(c => c.Email).
                HasMaxLength(100).
                IsRequired();

            modelBuilder.Entity<Flight>().HasKey(f => f.Number);//set primary key
            modelBuilder.Entity<Flight>().Property(f => f.DepartureCity).
                HasMaxLength(100).
                IsRequired();
            modelBuilder.Entity<Flight>().Property(f => f.ArrivalCity).
              HasMaxLength(100).
              IsRequired();


            modelBuilder.Entity<Flight>().
                HasOne(f => f.Airplane).
                WithMany(a => a.Flights).
                HasForeignKey(f => f.AirplaneId);

            modelBuilder.Entity<Flight>().HasMany(c => c.Clients).WithMany(c => c.Flights);



        }
    }
}

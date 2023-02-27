using _07_EF_example.Entities;
using _07_EF_example.Helpers;
using data_access_entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _07_EF_example
{
    public class AirplanesDbContext : DbContext
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
        public DbSet<ClientFligth> ClientFligth { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;
                                        Initial Catalog = AirplaneDataBase;
                                        Integrated Security=True;Connect Timeout=2;Encrypt=False;
                                        TrustServerCertificate=False;
                                        ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
            modelBuilder.Entity<Client>().HasIndex(c => c.Email).IsUnique();


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

            //modelBuilder.Entity<Flight>().HasMany(c => c.Clients).WithMany(c => c.Flights);
            modelBuilder.Entity<ClientFligth>().HasKey(cf => new { cf.FlightId, cf.ClientId });
            modelBuilder.Entity<ClientFligth>()
                .HasOne(c=>c.Client)
                .WithMany(c=>c.ClientFligth)
                .HasForeignKey(c=>c.ClientId);
            modelBuilder.Entity<ClientFligth>()
               .HasOne(c => c.Flight)
               .WithMany(c => c.ClientFligth)
               .HasForeignKey(c => c.FlightId);





            modelBuilder.Entity<Client>().HasKey(c => c.CredentialsId);
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Credentials)
                .WithOne(c => c.Client)
                .HasForeignKey<Client>(c => c.CredentialsId);
                //.HasForeignKey<Client>(c => c.CredentialsId); ;

            //Initializer - Seeder
            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFligths();
            modelBuilder.SeedCredentials();
            modelBuilder.SeedClient();
            modelBuilder.SeedClientFlight();




        }
    }
}

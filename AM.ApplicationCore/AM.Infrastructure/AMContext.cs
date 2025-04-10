using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
         public DbSet<Flight> flights {  get; set; }
        public DbSet<Passenger> passanger { get; set; }

        public DbSet<Plane> plane { get; set; }
        public DbSet<Staff> staff { get; set; }
        public DbSet<Traveller> traveller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new planeConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());

            //TPT
            modelBuilder.Entity<Staff>().ToTable(nameof(Staff));
            modelBuilder.Entity<Traveller>().ToTable(nameof(Traveller));

            base.OnModelCreating(modelBuilder);
            

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
                base.ConfigureConventions(configurationBuilder);
        }

    }
}

using BusDepot.Models;
using BusDepot1.Models;
using Microsoft.EntityFrameworkCore;


namespace DepotBus.Data
{
    public class DepotContext : DbContext

    {
        public DepotContext(DbContextOptions<DepotContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DepotContext()
        {

        }


        public DbSet<Bus> Buses { get; set; }

        public DbSet<Employee> Drivers { get; set; }

        public DbSet<Employee> Dispatchers { get; set; }

        public DbSet<Incident> Incidents { get; set; }

        public DbSet<Employee> Mechanics { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-7PGBHK6;database=BusDepot;trusted_connection=true;");
        }
    }
}
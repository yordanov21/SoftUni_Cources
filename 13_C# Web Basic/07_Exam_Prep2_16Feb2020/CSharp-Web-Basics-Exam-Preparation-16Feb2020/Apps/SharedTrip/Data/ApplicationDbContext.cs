namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions db)
            : base(db)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }


        // override OnConfiguring for our conection string 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DANE\\SQLEXPRESS;Database=SharedTrip;Integrated Security=true;");
            }
        }


        //override OnModelCreating to set Primary keys on the table UserTrip
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>().HasKey(x => new { x.TripId, x.UserId });

            base.OnModelCreating(modelBuilder);
        }
    }
}

namespace SharedTrip.Data
{
    public class UserTrip
    {
        //for Primary key-> override OnModelCreating in ApplicationDbContext to set Primary keys on the table UserTrip
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string TripId { get; set; }

        public virtual Trip Trip { get; set; }
    }
}

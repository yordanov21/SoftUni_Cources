namespace SharedTrip.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Trip
    {
        public Trip()
        {
            this.Id = Guid.NewGuid().ToString();  //set initial value for string Ids by Guid
            this.UserTrips = new HashSet<UserTrip>();
        }
        public string Id { get; set; }
        
        [Required]  //required for no null values
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        // by default DateTime is required. If you want nullable put ? after DateTime  (DateTime? DepartureTime)
        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }

        [Required]
        [MaxLength(80)]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public virtual ICollection<UserTrip> UserTrips { get; set; }

    }
}

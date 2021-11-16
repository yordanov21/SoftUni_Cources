namespace SharedTrip.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString(); //set initial value for string Ids by Guid
            this.UserTrips = new HashSet<UserTrip>();
        }
        public string Id { get; set; }
        
        [Required]       //required for no null values
        [MaxLength(20)]  //validation for min length can't be check here!!! 
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        //[MaxLength(20)] //maxlenght is not need here, because before go here we hashed the password and check the lenght
        public string Password { get; set; }

        //make collection for mapping table
        public virtual ICollection<UserTrip> UserTrips { get; set; }
    }
}

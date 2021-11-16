namespace P03_FootballBetting.Data.Models
{
    public class User
    {
        public int Userid { get; set; }

        public string Username { get; set; }

        //hashed password
        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }
    }
}

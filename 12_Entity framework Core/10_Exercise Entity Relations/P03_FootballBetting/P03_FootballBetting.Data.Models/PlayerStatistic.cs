namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        //TODO composite PK MAPING TABLE
        public int GameId { get; set; }

        public int PlayerId { get; set; }

        public byte ScoredGoals { get; set; }  //byte: 0 to 255

        public byte Assists { get; set; }  //byte: 0 to 255

        public byte MinutesPlayed { get; set; }

    }
}

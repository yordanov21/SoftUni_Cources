namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        public int Playerid { get; set; }

        public string Name { get; set; }

        public byte SquadNumber { get; set; }

        // TODO: nav prop
        public int TeamId { get; set; }

        public int PositionId { get; set; }

        public bool IsInjured { get; set; }
    }
}

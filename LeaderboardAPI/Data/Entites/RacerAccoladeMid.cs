namespace LeaderboardAPI.Date.Entites
{
    public class RacerAccoladeMid
    {
        public int RacerId { get; set; }

        public int  AccoladeId { get; set; }

        public DateTime DateTime { get; set; }

        public string? Reason { get; set; } = string.Empty;

    }

}
namespace LeaderboardAPI.Date.Entites
{
    public class RacerStatrsMid
    {
        public int Number { get; set; }

        public int RacerId { get; set; }

        public DateTime DateTime { get; set; }

        public string Reason { get; set; } = string.Empty;

        public bool? IsRad {  get; set; } = true ;
    }
}

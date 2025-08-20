namespace LeaderboardAPI.Date.Entites
{
    public class RacerAccolade : RacerAccoladeMid
    {

        public int Id { get; set; }

        public Racer racer { get; set; } = null!;

        public  Accolade  accolade { get; set; } = null!;

    }


}
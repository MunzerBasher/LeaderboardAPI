namespace LeaderboardAPI.Date.Entites
{


    public class RacerStatrs : RacerStatrsMid
    {
        public int Id { get; set; }

        public Racer racer { get; set; } = null!;

    }


}
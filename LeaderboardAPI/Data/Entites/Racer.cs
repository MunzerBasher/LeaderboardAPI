namespace LeaderboardAPI.Date.Entites
{
    
    public class Racer
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty ;

        public int TotalOfStart { get; set; }

        public ICollection<RacerAccolade> racerAccolade { get; set; } = [];

        public ICollection<RacerStatrs> racerStatrs { get; set; } = null!;

    }


}
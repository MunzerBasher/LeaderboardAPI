namespace LeaderboardAPI.Date.Entites
{
    
    public class Accolade
    {
        public int Id { get; set; }

        public string Name { get; set; }  = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public ICollection<RacerAccolade> accoladeAccolade { get; set; } = [];
    }


}
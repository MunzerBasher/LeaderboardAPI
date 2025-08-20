namespace LeaderboardAPI.Contracts
{
    public class RacerResponse
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int TotalOfStars {  get; set; }

        public ICollection<AccoladeResponse> Accolade { get; set; } = [];
    }

}
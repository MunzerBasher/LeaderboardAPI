namespace LeaderboardAPI.Contracts
{
    public class RacerResponseByDetails
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int TotalOfStars { get; set; }

        public ICollection<AccoladeResponse> Accolade { get; set; } = [];

        public ICollection<StartResponse> StartResponse { get; set; } = [];
    }


    public class StartResponse
    {
        public int Number { get; set; }

        public DateTime DateTime { get; set; }

        public string Reason { get; set; } = string.Empty;
    }

}

using Microsoft.AspNetCore.Identity;

namespace LeaderboardAPI.Date.Entites
{
    public class ApplicationUser : IdentityUser
    {

        public DateTime RegisteredAt { get; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool isEnable { get; set; }

    }


}
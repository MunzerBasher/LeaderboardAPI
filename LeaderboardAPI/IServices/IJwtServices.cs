using LeaderboardAPI.Date.Entites;

namespace LeaderboardAPI.IServices
{
    public interface IJwtServices
    {


        string GenarateJwt(ApplicationUser user);
    }
}
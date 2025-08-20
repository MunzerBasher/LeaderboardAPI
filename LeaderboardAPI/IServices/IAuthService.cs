using LeaderboardAPI.Contracts;

namespace LeaderboardAPI.IServices
{
    public interface IAuthService
    {

        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<bool> AddUser(string email, string password);

    }
}

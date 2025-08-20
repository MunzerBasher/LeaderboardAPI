using LeaderboardAPI.Contracts;
using LeaderboardAPI.IServices;
using LeaderboardAPI.Date.DbContext;
using LeaderboardAPI.Date.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace LeaderboardAPI.Services
{

    public class AuthService(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager,
        IJwtServices jwtServices ,
        SignInManager<ApplicationUser> signInManager
        ) : IAuthService
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IJwtServices _jwtServices = jwtServices ; 
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;


        public async Task<bool> AddUser(string email, string password)
        {
            var user = new ApplicationUser { Email = email,  FirstName = "",LastName = ""};
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Username);
            if (user == null)
                return null!;
            var result = await _signInManager.PasswordSignInAsync(user, request.Password,true, false);
            
            if(result.Succeeded)
            {
                string token =  _jwtServices.GenarateJwt(user);
                return new LoginResponse { Token = token };
            }
            return null!;
        }
    }

}
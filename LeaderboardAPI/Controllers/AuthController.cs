using LeaderboardAPI.Contracts;
using LeaderboardAPI.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LeaderboardAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("Login")]
            
        public async Task<ActionResult> LoginAsync(LoginRequest loginRequest)
        {
            var result  = await _authService.LoginAsync(loginRequest);

            return result is null ? BadRequest("InValid UserName Or Password") : Ok(result);
        }

        [HttpPost("Add")]

        public async Task<ActionResult> AddUserAsync(LoginRequest loginRequest)
        {
            var result = await _authService.AddUser(loginRequest.Username, loginRequest.Password);

            return result? BadRequest("InValid UserName Or Password") : Ok(result);
        }

    }

}
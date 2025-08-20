using LeaderboardAPI.Data.Entites;
using LeaderboardAPI.Date.Entites;
using LeaderboardAPI.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;


namespace LeaderboardAPI.Services
{
    public class JwtServices : IJwtServices
    {
        private readonly IOptions<Jwt> _jwt;

        public JwtServices(IOptions<Jwt> jwt)
        {
            _jwt = jwt;
        }

        public string GenarateJwt(ApplicationUser user)
        {
            Claim[] claims =
            [
                    new (JwtRegisteredClaimNames.Sub, user.Id ),
                    new (JwtRegisteredClaimNames.Email,user.Email! ),
                    new (JwtRegisteredClaimNames.GivenName, user.FirstName ),
                    new (JwtRegisteredClaimNames.FamilyName,user.LastName ),
                    new (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString() ),
            ];
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Value.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();
            var expiresIn = 30;

            var token = new JwtSecurityToken(
                issuer: _jwt.Value.Issure,
                audience: _jwt.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresIn),
                signingCredentials: signingCredentials
            );
            var Jwttoken = new JwtSecurityTokenHandler().WriteToken(token);
            return Jwttoken ;


        }


    }


}
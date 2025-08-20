using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentValidation.AspNetCore;
using LeaderboardAPI.Data.Entites;
using System.Reflection;
using FluentValidation;
using System.Text;

namespace LeaderboardAPI
{

    public static class Dependecies
    {


        public static IServiceCollection AddJwtDependecies(this IServiceCollection Services, IConfiguration Configuration)
        {
            var jwt = Configuration.GetSection("Jwt").Get<Jwt>();
            Services.Configure<Jwt>(Configuration.GetSection(nameof(Jwt)));
            Services.AddScoped(typeof(Jwt));
            Services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
                AddJwtBearer(
                optins =>
                {
                    optins.SaveToken = true;
                    optins.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidAudience = jwt!.Audience,
                        ValidIssuer = jwt.Issure,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
                    };
                });

            return Services;
        }
    }
}
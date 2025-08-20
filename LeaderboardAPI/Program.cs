using LeaderboardAPI;
using FluentValidation;
using System.Reflection;
using LeaderboardAPI.Services;
using LeaderboardAPI.IServices;
using FluentValidation.AspNetCore;
using LeaderboardAPI.Date.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LeaderboardAPI.Date.Entites;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("Server=db25474.databaseasp.net; Database=db25474; User Id=db25474; Password=xT%7@h9G5Sk?; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;")));


builder.Services.AddJwtDependecies(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


builder.Services.AddScoped<IRacerServices, RacerServices>();
builder.Services.AddScoped<IAccoladeService, AccoladeService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtServices, JwtServices>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


//builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        Policy =>
        {
            Policy.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


var app = builder.Build();

//// Configure the HTTP request pipeline.
//app.MapScalarApiReference();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

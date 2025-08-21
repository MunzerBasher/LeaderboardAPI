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
using Microsoft.AspNetCore.HttpOverrides;



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

// CORS: configurable allowed origins (if none provided, allow any for dev)
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        if (allowedOrigins.Length > 0)
        {
            policy.WithOrigins(allowedOrigins)
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        }
        else
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        }
    });
});

// Kestrel HTTPS configuration: use certificate if provided via config or env vars
// Config keys: Kestrel:Certificates:Default:Path and ...:Password
var certPath = builder.Configuration["Kestrel:Certificates:Default:Path"]
               ?? Environment.GetEnvironmentVariable("ASPNETCORE_Kestrel__Certificates__Default__Path");
var certPassword = builder.Configuration["Kestrel:Certificates:Default:Password"]
                  ?? Environment.GetEnvironmentVariable("ASPNETCORE_Kestrel__Certificates__Default__Password");

var httpPort = builder.Configuration.GetValue<int?>("Kestrel:Endpoints:Http:Port") ?? 5000;
var httpsPort = builder.Configuration.GetValue<int?>("Kestrel:Endpoints:Https:Port") ?? 5001;

    // Kestrel is configured via appsettings.json/environment variables.

var app = builder.Build();

//// Configure the HTTP request pipeline.
//app.MapScalarApiReference();

app.UseSwagger();
app.UseSwaggerUI();

// Respect X-Forwarded-* headers when behind a reverse proxy (e.g., Nginx)
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

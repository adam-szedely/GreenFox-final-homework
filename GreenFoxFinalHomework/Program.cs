using System.ComponentModel.Design;
using System.Text;
using System.Text.Json.Serialization;
using GreenFoxFinalHomework.Services;
using GreenFoxFinalHomework.Services.Interfaces;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using GreenFoxFinalHomework.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IListingService, ListingService>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


ConfigureDb(builder.Services);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


var app = builder.Build();

app.MapControllers();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.Run();

static void ConfigureDb(IServiceCollection services)
{
var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
var connectionString = config.GetConnectionString("Default");
services.AddDbContext<ApplicationDbContext>(b => b.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
}
public partial class Program { }

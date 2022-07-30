using System.ComponentModel.Design;
using System.Text;
using System.Text.Json.Serialization;
using GreenFoxFinalHomework.Services;
using GreenFoxFinalHomework.Services.Interfaces;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using GreenFoxFinalHomework.Database;
using GreenFoxFinalHomework.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddScoped<IUserService, UserService>();

ConfigureDb(builder.Services);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
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

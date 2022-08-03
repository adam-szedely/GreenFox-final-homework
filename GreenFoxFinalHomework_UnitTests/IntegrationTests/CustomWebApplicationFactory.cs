using System;
using GreenFoxFinalHomework.Models;
using GreenFoxFinalHomework.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GreenFoxFinalHomework_UnitTests.IntegrationTests
{
        public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
        {
            protected override void ConfigureWebHost(IWebHostBuilder builder)
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<ApplicationDbContext>));

                    services.Remove(descriptor);

                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                    });

                    var sp = services.BuildServiceProvider();

                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                        db.Database.EnsureCreated();

                        try
                        {
                            db.Users.Add(new User { Id = 1, UserName = "Test1", Email = "Test1@test.com", Password = "test1", Items = new List<Item>(), UserBids = new List<Bid>() }) ;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                });
            }
        }
    }

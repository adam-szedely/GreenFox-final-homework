using System;
using GreenFoxFinalHomework.Database;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using GreenFoxFinalHomework.Models;

namespace GreenFoxFinalHomework.Database
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Bid> Bids { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Items).WithOne(i => i.User);
            modelBuilder.Entity<User>().Property(u => u.UserName).HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.UserName).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Item>().HasOne(i => i.User).WithMany(u => u.Items);

            modelBuilder.Entity<Bid>().HasOne(b => b.User).WithMany(u => u.UserBids);
            modelBuilder.Entity<Bid>().HasOne(b => b.Item).WithMany(i => i.ItemBids);

            modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "Test1", Password = "Test1", Email = "test1@test.com" , Items = new List<Item>() });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, UserName = "Test2", Password = "Test2", Email = "test2@test.com", Items = new List<Item>() });
            modelBuilder.Entity<User>().HasData(new User { Id = 3, UserName = "Test3", Password = "Test3", Email = "test3@test.com", Items = new List<Item>() });
        }

        IQueryable<T> IApplicationDbContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}
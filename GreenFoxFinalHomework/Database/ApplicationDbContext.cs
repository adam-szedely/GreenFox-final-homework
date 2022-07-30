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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        IQueryable<T> IApplicationDbContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}
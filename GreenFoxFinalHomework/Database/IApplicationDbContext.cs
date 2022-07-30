using System;
using GreenFoxFinalHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenFoxFinalHomework.Database
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Bid> Bids { get; set; }

        IQueryable<T> Set<T>() where T : class;

        int SaveChanges();
    }
}


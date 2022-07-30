using System;
namespace GreenFoxFinalHomework.Database
{
    public interface IApplicationDbContext
    {
        IQueryable<T> Set<T>() where T : class;

        int SaveChanges();
    }
}


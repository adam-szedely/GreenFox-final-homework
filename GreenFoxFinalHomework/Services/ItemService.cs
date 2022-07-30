using System;
using GreenFoxFinalHomework.Services.Interfaces;
using GreenFoxFinalHomework.Database;
namespace GreenFoxFinalHomework.Services
{
    public class ItemService : IItemService
    {
        private readonly IApplicationDbContext dbContext;

        public ItemService(IApplicationDbContext data)
        {
            this.dbContext = data;
        }
    }
}


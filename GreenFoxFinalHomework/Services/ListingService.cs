using System;
using GreenFoxFinalHomework.Services.Interfaces;
using GreenFoxFinalHomework.Database;
using GreenFoxFinalHomework.Models;

namespace GreenFoxFinalHomework.Services
{
    public class ListingService : IListingService
    {
        private readonly IApplicationDbContext data;

        public ListingService(IApplicationDbContext data)
        {
            this.data = data;
        }

        public Item CreateItem(string name, string description, string photoUrl, int startingPrice, int userId)
        {
            var itemToBeCreated = new Item(name, description, photoUrl, startingPrice, userId);
            data.Items.Add(itemToBeCreated);
            return itemToBeCreated;
        }

        public List<Item> ListItems()
        {
            if (data.Items.Count() == 0)
            {
                return new List<Item>();
            }
            return data.Items.ToList();
        }

        public List<Item> ListItems(int howMany)
        {
            if (data.Items.Count() == 0)
            {
                return new List<Item>();
            }
            return data.Items.Where(i => i.Id > howMany).Take(20).ToList();
        }

        public Item ViewItem(int id)
        {
            throw new NotImplementedException();
        }

        public bool ListingValidator()
        {
            return true;
        }
    }
}


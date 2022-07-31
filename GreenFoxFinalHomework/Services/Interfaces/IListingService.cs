using System;
using GreenFoxFinalHomework.Models;

namespace GreenFoxFinalHomework.Services.Interfaces
{
    public interface IListingService
    {
        Item CreateItem(string name, string description, string photoUrl, double startingPrice, int userId);
        Item ViewItem(int id);
        List<Item> ListItems();
        List<Item> ListItems(int howMany);
    }
}


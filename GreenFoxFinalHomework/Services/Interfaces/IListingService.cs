using System;
using GreenFoxFinalHomework.Models;

namespace GreenFoxFinalHomework.Services.Interfaces
{
    public interface IListingService
    {
        Item CreateItem(string name, string description, string photoUrl, int startingPrice, int userId);
        Item ViewItem(int id);
        Item BuyItem(int id, int purchasePrice);
        List<Item> ListItems();
        List<Item> ListItems(int howMany);
    }
}


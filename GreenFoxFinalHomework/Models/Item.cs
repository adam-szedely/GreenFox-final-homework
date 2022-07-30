using System;
namespace GreenFoxFinalHomework.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemPhotoUrl { get; set; }
        public double ItemStartingPrice { get; set; }
        public double ItemPurchasePrice { get; set; }

        public Item(string name, string description, string photoUrl, double startingPrice, double purchasePrice)
        {
            this.ItemName = name;
            this.ItemDescription = description;
            this.ItemPhotoUrl = photoUrl;
            this.ItemStartingPrice = startingPrice;
            this.ItemPurchasePrice = purchasePrice;
        }
    }
}

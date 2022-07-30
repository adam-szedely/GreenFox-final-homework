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
        public int UserId { get; set; }
        public List<Bid> ItemBids { get; set; }

        public Item(string name, string description, string photoUrl, double startingPrice, double purchasePrice, int userId)
        {
            this.ItemName = name;
            this.ItemDescription = description;
            this.ItemPhotoUrl = photoUrl;
            this.ItemStartingPrice = startingPrice;
            this.ItemPurchasePrice = purchasePrice;
            this.UserId = userId;
        }
    }
}

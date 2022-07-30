using System;
namespace GreenFoxFinalHomework.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemPhotoUrl { get; set; }
        public int ItemStartingPrice { get; set; }
        public int ItemPurchasePrice { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Bid> ItemBids { get; set; }

        public Item()
        {

        }
        public Item(string name, string description, string photoUrl, int startingPrice, int userId)
        {
            this.ItemName = name;
            this.ItemDescription = description;
            this.ItemPhotoUrl = photoUrl;
            this.ItemStartingPrice = startingPrice;
            this.UserId = userId;
        }
    }
}

using System;
namespace GreenFoxFinalHomework.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int BidValue { get; set; }
        public User User { get; set; }
        public Item Item { get; set; }

        public Bid()
        {
        }
    }
}


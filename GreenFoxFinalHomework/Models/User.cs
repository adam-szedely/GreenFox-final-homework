using System;
namespace GreenFoxFinalHomework.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Item> Items { get; set; }
        public List<Bid> UserBids { get; set; }

        public User()
        {
        }

        public User(string username, string password, string email)
        {
            UserName = username;
            Password = password;
            Email = email;
        }
    }
}


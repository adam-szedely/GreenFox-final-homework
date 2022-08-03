using System;
namespace GreenFoxFinalHomework.Models.DTOs
{
    public class UserRegistrationDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserRegistrationDTO(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
    }
}


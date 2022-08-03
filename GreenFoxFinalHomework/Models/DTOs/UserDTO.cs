using System;
namespace GreenFoxFinalHomework.Models.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }

        public UserDTO(int userId, string userName, string password, string email)
        {
            UserId = userId;
            UserName = userName;
            PassWord = password;
        }
    }
}


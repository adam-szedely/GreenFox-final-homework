using System;
namespace GreenFoxFinalHomework.Models.DTOs
{
    public class UserLoginInfoDTO
    {
        public string Message { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}


using System;
using GreenFoxFinalHomework.Models;
using GreenFoxFinalHomework.Models.DTOs;

namespace GreenFoxFinalHomework.Services.Interfaces
{
    public interface IUserService
    {
        UserDTO CheckIfUserIsValid(UserDTO user);
        string CreateToken(UserDTO user);
        UserLoginInfoDTO GetCurrentUser(string jwt);
        UserRegistrationDTO RegisterUser(UserRegistrationDTO user);
        bool IsUsernameTaken(UserRegistrationDTO user);
        bool IsPasswordTooShort(UserRegistrationDTO user);
    }
}


using System;
using GreenFoxFinalHomework.Services.Interfaces;
using GreenFoxFinalHomework.Database;
using GreenFoxFinalHomework.Models.DTOs;
using GreenFoxFinalHomework.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Configuration;

namespace GreenFoxFinalHomework.Services
{
    public class UserService : IUserService
    {
        private IApplicationDbContext data;
        private IConfiguration configuration;

        public UserService(IApplicationDbContext data, IConfiguration configuration)
        {
            this.data = data;
            this.configuration = configuration;
        }
        public UserRegistrationDTO RegisterUser(UserRegistrationDTO user)
        {
            data.Users.Add(new User()
            {
                UserName = user.Username,
                Email = user.Email,
                Password = user.Password,
            });
            data.SaveChanges();
            return new UserRegistrationDTO(user.Username, user.Email, user.Password);
        }

        public UserDTO CheckIfUserIsValid(UserDTO user)
        {
            var currentUser = data.Users.FirstOrDefault(p => p.UserName.ToLower() ==
        user.UserName.ToLower() && p.Password == user.PassWord);
            UserDTO returnUser = new UserDTO(currentUser.Id, currentUser.UserName, currentUser.Password, currentUser.Email);
            if (currentUser != null)
            {
                return returnUser;
            }
            return null;
        }

        public string CreateToken(UserDTO user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim("UserId",user.UserId.ToString()),
                new Claim("Username", user.UserName),
            };

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken GetClaimsPrincipal(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken.Replace("Bearer ", "")) as JwtSecurityToken;

            return jsonToken;
        }

        public UserLoginInfoDTO GetCurrentUser(string jwt)
        {
            if (jwt != null)
            {
                var userClaims = GetClaimsPrincipal(jwt.Replace("Bearer ", ""));

                return new UserLoginInfoDTO
                {
                    UserId = int.Parse(userClaims.Claims.FirstOrDefault(c => c.Type == "UserId").Value),
                    Username = userClaims.Claims.FirstOrDefault(c => c.Type == "Username").Value,
                };
            }
            return null;
        }

        public bool IsUsernameTaken(UserRegistrationDTO user)
        {
            if (user.Username == null)
                return true;
            return data.Users.Any(p => p.UserName.ToLower().Equals(user.Username.ToLower()));
        }

        public bool IsPasswordTooShort(UserRegistrationDTO user)
        {
            if (user.Password.Length < 8)
            {
                return true;
            }
            return false;
        }
    }
}


using System;
using GreenFoxFinalHomework.Services.Interfaces;
using GreenFoxFinalHomework.Database;
namespace GreenFoxFinalHomework.Services
{
    public class UserService : IUserService
    {

        private readonly IApplicationDbContext data;
        public UserService(IApplicationDbContext data)
        {
            this.data = data;
        }
    }
}


using DataAcessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IUserService
    {
        void InsertUser(UserSignUp userSignUp);
        //Task<string> AuthenticateUserAndGetToken(UserSignUp loginUser);
        //string GenerateToken(UserSignUp user);
        Task<UserSignUp> GetUserByEmail(string Email);
        void Save();
        
    }
}

using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PracticeProject.Data;
using PracticeProject.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly SchoolContext _context;
       

        public UserRepository(SchoolContext context)
        {
            _context = context;
            
        }
        public void InsertUser(UserSignUp userSignUp)
        {
            _context.Users.Add(userSignUp);
            
        }
        public async  Task<UserSignUp> GetUserByEmailAsync(string Email)
        {
            return await  _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
            
            
            
        }



        public void Save()
        {
            _context.SaveChanges();
        }

        


    }
}

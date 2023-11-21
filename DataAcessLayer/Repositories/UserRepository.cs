using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using PracticeProject.Data;
using PracticeProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}

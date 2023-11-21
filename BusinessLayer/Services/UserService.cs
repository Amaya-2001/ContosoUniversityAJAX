using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using PracticeProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            
            _userRepository = userRepository;
        }

        public void InsertUser(UserSignUp user)
        {
            _userRepository.InsertUser(user);
        }
        public void Save()
        {
            _userRepository.Save();
        }
    }
}

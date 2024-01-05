using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using PracticeProject.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _config = configuration; // Inject the configuration object
        }

        public void InsertUser(UserSignUp user)
        {

            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));


            user.Password = hashedPassword;
            user.PasswordSalt = Convert.ToBase64String(salt);
            _userRepository.InsertUser(user);
        }
        public void Save()
        {
            _userRepository.Save();
        }
        public async Task<UserSignUp> GetUserByEmail(string Email)
        {

           return await  _userRepository.GetUserByEmailAsync(Email);

        }

    }
}

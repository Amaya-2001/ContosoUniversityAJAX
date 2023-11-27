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

        //public async Task<string> AuthenticateUserAndGetToken(UserSignUp loginUser)
        //{
        //    try
        //    {
        //        if (loginUser == null)
        //        {
        //            // Log or handle the case where loginUser is null
        //            Console.WriteLine("loginUser is null.");
        //            return null;
        //        }

        //        Console.WriteLine(loginUser);
        //        var storedUser = await _userRepository.GetUserByEmail(loginUser.Email);
        //        Console.WriteLine(storedUser);

        //        if (storedUser != null && VerifyPassword(loginUser.Password, storedUser))
        //        {
        //            // Password matches, generate and return the JWT token

        //            return GenerateToken(storedUser);
        //        }

        //        return null; // Authentication failed
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle the exception
        //        Console.WriteLine("Exception in AuthenticateUserAndGetToken: " + ex.Message);
        //        return null;
        //    }
        //}

        //private bool VerifyPassword(string inputPassword, UserSignUp storedUser)
        //{
        //    // Compare the provided password with the stored hashed password
        //    byte[] salt = Convert.FromBase64String(storedUser.PasswordSalt);
        //    string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //        password: inputPassword,
        //        salt: salt,
        //        prf: KeyDerivationPrf.HMACSHA256,
        //        iterationCount: 100000,
        //        numBytesRequested: 256 / 8));

        //    return hashedPassword == storedUser.Password;
        //}

        //public string GenerateToken(UserSignUp user)
        //{

        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config[key: "Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Issuer"],
        //      null,
        //      expires: DateTime.Now.AddMinutes(30),
        //      signingCredentials: credentials);


        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        public async Task<UserSignUp> GetUserByEmail(string Email)
        {

           return await  _userRepository.GetUserByEmailAsync(Email);

        }

    }
}

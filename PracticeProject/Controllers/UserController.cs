using Azure;
using BusinessLayer.Services;
using DataAcessLayer.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using PracticeProject.Helpers;
using PracticeProject.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PracticeProject.Controllers
{

    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        //Get: user registration
        public IActionResult SignUp()
        {
            // You can customize this to pass any necessary data to your view

            return View("SignUp");
        }

        [HttpPost, ActionName("SignUpPost")]
        public JsonResult SignUpPost([Bind("UserID,Email,UserName,Password,PasswordSalt")] UserSignUpModel signupModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = MappingUserApplication.ToCreateUser(signupModel);
                    Console.Write("user.UserID" + user.UserID);
                    _userService.InsertUser(user);
                    _userService.Save();

                    Console.WriteLine("User saved successfully!");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                ModelState.AddModelError("", "Student sign up not successful!");
            }
            return Json(new { Success = true });
        }

        //Get: user login page
        public ViewResult Login()
        {
            // You can customize this to pass any necessary data to your view

            return View("Login");
        }
        //User login
        [HttpPost]
        [ActionName("LoginPost")]
        public async Task<JsonResult> LoginPost([Bind("Email, Password")] UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var storedUser = await _userService.GetUserByEmail(userLoginModel.Email);
                    if (storedUser == null)
                    {
                        // User not found
                        return Json(new { success = false, error = "User not found" });
                    }
                    byte[] salt = Convert.FromBase64String(storedUser.PasswordSalt);

                    string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: userLoginModel.Password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8));

                    

                    // Use a secure comparison method
                    if (SecureStringEquals(hashedPassword, storedUser.Password))
                    {
                        return Json(new { Success = true });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, error = ex.Message });
                }
            }

            // Handle ModelState.IsValid is false
            return Json(new { success = false, error = "Model validation failed" });
        }

        private static bool SecureStringEquals(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }









        //User dashboard
        public IActionResult DashBoard()
    {
        return View();
    }





    }
}

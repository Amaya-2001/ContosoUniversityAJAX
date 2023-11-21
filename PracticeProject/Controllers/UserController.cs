using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using PracticeProject.Helpers;
using PracticeProject.Models;

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

        [HttpPost,ActionName("SignUpPost")]
        public JsonResult SignUpPost([Bind("UserID,Email,UserName,Password")] UserSignUpModel signupModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = MappingUserApplication.ToCreateUser(signupModel);
                    Console.Write(user.UserID);
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
        public IActionResult Login()
        {
            // You can customize this to pass any necessary data to your view

            return View("Login");
        }

    }
}

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
       
        public ActionResult Index()
        {
            Console.WriteLine("HI");
            return View();
        }
        public JsonResult Create([Bind("UserName,Email,Password")] UserSignUpModel signupModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = MappingUserApplication.ToCreateUser(signupModel);
                    _userService.InsertUser(user);
                    _userService.Save();

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Student sign up not successfully!");
            }
            return Json(new { Success = true });
        }

    }
}

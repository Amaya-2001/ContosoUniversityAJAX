using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Models;
using System.Data;
using BusinessLayer.Repositories;
using static BusinessLayer.Services.StudentService;
using BusinessLayer.Services;
using BusinessLayer.Interfaces;
using PracticeProject.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace PracticeProject.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
       
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            
            
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetStudentList()
        {
            var students = await _studentService.GetStudents();
            var studentModel = ServiceConfigureExtensions.ToStudentModelList(students);
            //return Ok(studentModel);
            //return Json(studentModel);
            return PartialView("~/Views/Students/PartialViews/StudentList.cshtml", studentModel);

        }

        // Get: Students/Details

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            return View(id);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetStudentDetails(int id)
        {
            var student = await _studentService.GetStudentByID(id);
            var studentModel = ServiceConfigureExtensions.ToStudentModel(student);
            return PartialView("~/Views/Students/PartialViews/StudentDetailsPartial.cshtml", studentModel);
        }
        //GET: Students/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }
        //Post Students/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
       
        public  JsonResult Create([Bind("ID,EnrollmentDate,FirstMidName,LastName")] StudentModel studentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = ServiceConfigureExtensions.ToCreateStudent(studentModel);
                     _studentService.InsertStudent(student);
                    _studentService.Save();
                    return  Json(new { success = true });
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return Json(new { success = false });
        }

        //GET: Student/UPDATE
        [AllowAnonymous]
        public IActionResult Edit()
        {
            return View();
        }
       
        [HttpGet, ActionName("Edit")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByID(id.Value);

            if (student == null)
            {
                return NotFound();
            }

            var studentModel = ServiceConfigureExtensions.ToStudentModel(student);

            return View(studentModel);
        }
        
        [HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> EditPost(int? id)
        {
            if (id == null)
            {
                return Json(new { success = true });
            }
            var student = await _studentService.GetStudentByID(id.Value);
            var studentModel = ServiceConfigureExtensions.ToStudentModel(student);
            try
            {
                var updateStudent = ServiceConfigureExtensions.UpdateStudent(studentModel, student);
                _studentService.UpdateStudent(updateStudent);
                _studentService.Save();
                return Json(new { success = true }, updateStudent);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save");
            }

            //if (await TryUpdateModelAsync(studentModel, "",
            //    s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            //{
            //    try
            //    {
            //        var updateStudent = ServiceConfigureExtensions.UpdateStudent(studentModel, student);
            //        _studentService.UpdateStudent(updateStudent);
            //        _studentService.Save();
            //        return Json(new { success = true },updateStudent);
            //    }
            //    catch (DbUpdateException)
            //    {
            //        ModelState.AddModelError("", "Unable to save");
            //    }
            //}
            return Json(new { success = true });
        }
        //GET: Students/DELETE
        [AllowAnonymous]
        public IActionResult Delete()
        {
            return View();
        }

        
        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByID(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            var studentModel = ServiceConfigureExtensions.ToStudentModel(student);
            return View(studentModel);
        }

        // POST: Students/Delete/5
        
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteConfirm(int? id)
        {
            _studentService.DeleteStudent(id.Value);
            _studentService.Save();
            return Json(new { success = true });
        }
    }
}



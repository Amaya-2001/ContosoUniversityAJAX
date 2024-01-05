using AutoMapper;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Data;
using PracticeProject.Entities;
using PracticeProject.Helpers;
using PracticeProject.Models;


namespace PracticeProject.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {

        private readonly ICourseService _courseService;


        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetCourseList()
        {
            var courses = await _courseService.GetCourses();
            var courseModel = CourseServiceCfg.ToCourseList(courses);
            //return Ok(courseModel);
            return PartialView("~/Views/Courses/PartialViews/CourseListPartial.cshtml", courseModel);
        }

        [AllowAnonymous]
        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View(id);

        }
        [AllowAnonymous]
        public async Task<IActionResult> GetCourseDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _courseService.GetCourseByID(id.Value);
            var courseModel = CourseServiceCfg.ToGetCourse(course);
            return PartialView("~/Views/Courses/PartialViews/CourseDetailsPartial.cshtml", courseModel);

        }

        // GET: Students/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }
        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<JsonResult> Create([Bind("CourseID,Title,Credits")] CourseModel courseViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var courseEntity = CourseServiceCfg.ToCreateCourse(courseViewModel);
                    _courseService.InsertCourse(courseEntity);
                    _courseService.Save();
                    return Json(new { success = true });
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return Json(new { success = true });
        }
        // GET: Courses/Edit/5
        [AllowAnonymous]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetCourseByID(id.Value);

            if (course == null)
            {
                return NotFound();
            }

            var courseModel = CourseServiceCfg.ToGetCourse(course);

            return View(courseModel);
        }
        // POST: Courses/Edit/5
        
        [HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> EditCourse(int? id)
        {
            if (id == null)
            {
                return Json(new { success = true });
            }
            var course = await _courseService.GetCourseByID(id.Value);
            var courseModel = CourseServiceCfg.ToGetCourse(course);
            
            if (await TryUpdateModelAsync(courseModel, "",
                c => c.Title, c => c.Credits
                ))
            {
                try
                {
                   var updateCourse =  CourseServiceCfg.UpdateCourse(courseModel, course);
                    _courseService.UpdateCourse(updateCourse);
                    _courseService.Save();
                  
                    return Json(new { success = true });
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }

            }

            return Json(new { success = true });


        }
        //GET: Courses/DELETE
        [AllowAnonymous]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpGet, ActionName("Delete")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetCourseByID(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            var courseModel = CourseServiceCfg.ToGetCourse(course);
            return View(courseModel);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteConfirm(int? id)
        {
            _courseService.DeleteCourse(id.Value);
            _courseService.Save();
            return Json(new { success = true });
        }
    }
}


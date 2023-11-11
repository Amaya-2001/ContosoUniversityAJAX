using AutoMapper;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Helpers;
using PracticeProject.Models;

namespace PracticeProject.Controllers
{
    public class CoursesController : Controller
    {

        private readonly ICourseService _courseService;


        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetCourses();
            var courseModel = CourseServiceCfg.ToCourseList(courses);
            return View(courseModel);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _courseService.GetCourseByID(id.Value);
            var courseModel = CourseServiceCfg.ToGetCourse(course);
            return View(courseModel);

        }
        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,Title,Credits")] CourseModel courseViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var courseEntity = CourseServiceCfg.ToCreateCourse(courseViewModel);
                    _courseService.InsertCourse(courseEntity);
                    _courseService.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return View(courseViewModel);
        }
        // GET: Courses/Edit/5
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCourse(int? id)
        {
            if (id == null)
            {
                return NotFound();
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
                  
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }

            }

            return View(courseModel);


        }
        //GET: Courses/DELETE
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            _courseService.DeleteCourse(id.Value);
            _courseService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}


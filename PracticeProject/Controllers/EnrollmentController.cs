﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Data;
using PracticeProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessLayer.Services;
using PracticeProject.Helpers;

namespace PracticeProject.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;


        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        private SelectList CreateSelectList<T>(IEnumerable<T> items, Func<T, string> valueSelector, Func<T, string> textSelector)
        {
            var SelectList = new SelectList(items.Select(item => new SelectListItem
            {
                Value = valueSelector(item),
                Text = $"{valueSelector(item)}.{textSelector(item)}"
            }), "Value", "Text");
            return SelectList;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> GetEnrollmentList()
        {
            var enrollments = await _enrollmentService.GetEnrollments();
            var enrollmentModel = EnrollmentServicesCfg.ToEnrollmentList(enrollments);
            return PartialView("~/Views/Enrollments/PartialViews/EnrollmentListPartial.cshtml", enrollmentModel);
        }

        //Get: Enrollment/Details
        public async Task<IActionResult> Details(int? id)
        {
           
            return View(id);
        }
        public async Task<IActionResult> GetEnrollmentDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _enrollmentService.GetEnrollmentByID(id.Value);
            var enrollmentModel = EnrollmentServicesCfg.ToEnrollmentDetails(enrollment);
            return PartialView("~/Views/Enrollments/PartialViews/EnrollmentDetailsPartial.cshtml", enrollmentModel);
        }

        //GET: Enrollments/Create
        public async Task<ViewResult> Create()
        {
            var courses = await _enrollmentService.GetCourses();
            var students = await _enrollmentService.GetStudentIDs();
            var gradeValues = Enum.GetValues(typeof(Grade)).Cast<int>();

            ViewData["Course"] = CreateSelectList(courses, c => c.CourseID.ToString(), c => c.Title);
            ViewData["Student"] = CreateSelectList(students, s=>s.ID.ToString(), s=>s.LastName);
            ViewData["Grade"] = CreateSelectList(gradeValues, value => value.ToString(), value => Enum.GetName(typeof(Grade), value));

            return View();
        }

       

        //Post Students/Create
        [HttpPost, ActionName("Create")]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([Bind("EnrollmentID, CourseID,StudentID, Grade")] EnrollmentModel enrollmentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var enrollment = EnrollmentServicesCfg.ToCreateEnrollment(enrollmentModel);
                    _enrollmentService.InsertEnrollment(enrollment);
                    _enrollmentService.Save();
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
        //GET: Enrollment/Edit
        
        [HttpGet, ActionName("Edit")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _enrollmentService.GetEnrollmentByID(id.Value);

            if (enrollment == null)
            {
                return NotFound();
            }

            var enrollmentModel = EnrollmentServicesCfg.ToEnrollmentDetails(enrollment);

            ViewData["CourseID"] = new SelectList(await _enrollmentService.GetCourses());
            ViewData["StudentID"] = new SelectList(await _enrollmentService.GetStudentIDs());

            return View(enrollmentModel);
        }
        [HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> EditPost(int? id)
        {
            if (id == null)
            {
                return Json(new { success = true });
            }
            var enrollment = await _enrollmentService.GetEnrollmentByID(id.Value);
            var enrollmentModel = EnrollmentServicesCfg.ToEnrollmentDetails(enrollment);

            if (await TryUpdateModelAsync(enrollmentModel, "",e =>e.CourseID,e => e.StudentID,
                e => e.Grade))
            {
                try
                {
                    var updateEnrollment = EnrollmentServicesCfg.UpdateEnrollment(enrollmentModel, enrollment);
                    _enrollmentService.UpdateEnrollment(updateEnrollment);
                    _enrollmentService.Save();
                    return Json(new { success = true });
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save");
                }
            }
            return Json(new { success = true });
        }
        // GET: Enrollments/Delete/5
        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _enrollmentService.GetEnrollmentByID(id.Value);
            //Console.WriteLine(enrollment);
            if (enrollment == null)
            {
                return NotFound();
            }
            var enrollmentModel = EnrollmentServicesCfg.ToEnrollmentDetails(enrollment);

            return View(enrollmentModel);
        }
        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteConfirm(int? id)
        {
            _enrollmentService.DeleteEnrollment(id.Value);
            _enrollmentService.Save();
            return Json(new { success = true });
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Helpers;
using BusinessLayer.Services;

namespace PracticeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

      
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [Route("index")]
    [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetStudents();
            var studentModel = ServiceConfigureExtensions.ToStudentModelList(students);
            return Ok(studentModel);
        }
        // Get: Students/Details
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.GetStudentByID(id);
            var studentModel = ServiceConfigureExtensions.ToStudentModel(student);
            return Ok(studentModel);
        }
        //GET: Students/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //Post Students/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind("ID,EnrollmentDate,FirstMidName,LastName")] StudentModel studentModel)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var student = ServiceConfigureExtensions.ToCreateStudent(studentModel);
        //            _studentService.InsertStudent(student);
        //            _studentService.Save();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (DbUpdateException /* ex */)
        //    {
        //        Log the error(uncomment ex variable name and write a log.
        //        ModelState.AddModelError("", "Unable to save changes. " +
        //            "Try again, and if the problem persists " +
        //            "see your system administrator.");
        //    }

        //    return View(studentModel);
        //}

        //GET: Student/UPDATE
        //public IActionResult Edit()
        //{
        //    return View();
        //}

        //[HttpGet, ActionName("Edit")]

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _studentService.GetStudentByID(id.Value);

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    var studentModel = ServiceConfigureExtensions.ToStudentModel(student);

        //    return View(studentModel);
        //}
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditPost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var student = await _studentService.GetStudentByID(id.Value);
        //    var studentModel = ServiceConfigureExtensions.ToStudentModel(student);

        //    if (await TryUpdateModelAsync(studentModel, "",
        //        s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
        //    {
        //        try
        //        {
        //            var updateStudent = ServiceConfigureExtensions.UpdateStudent(studentModel, student);
        //            _studentService.UpdateStudent(updateStudent);
        //            _studentService.Save();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbUpdateException)
        //        {
        //            ModelState.AddModelError("", "Unable to save");
        //        }
        //    }
        //    return View(studentModel);
        //}
        //GET: Students/DELETE
        //public IActionResult Delete()
        //{
        //    return View();
        //}

        //[HttpGet, ActionName("Delete")]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _studentService.GetStudentByID(id.Value);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    var studentModel = ServiceConfigureExtensions.ToStudentModel(student);
        //    return View(studentModel);
        //}

        //POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirm(int? id)
        //{
        //    _studentService.DeleteStudent(id.Value);
        //    _studentService.Save();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}



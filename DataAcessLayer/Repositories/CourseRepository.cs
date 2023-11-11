using DataAcessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Data;
using PracticeProject.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _context;

        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }

        public void DeleteCourse(int courseID)
        {
            Course course = _context.Courses.Find(courseID);
            _context.Courses.Remove(course);
        }

        public async Task<Course> GetCourseByID(int courseID)
        {
            return  _context.Courses.Find(courseID);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _context.Courses.ToListAsync(); 
        }

        public void InsertCourse(Course course)
        {
             _context.Courses.Add(course);
        }
        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

       
    }
}

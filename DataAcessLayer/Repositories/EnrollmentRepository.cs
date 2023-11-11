using DataAcessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Data;
using PracticeProject.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly SchoolContext _context;

        public EnrollmentRepository(SchoolContext context)
        {
            _context = context;
        }
        public void DeleteEnrollment(int enrollmentId)
        {
            Enrollment enrollment = _context.Enrollments.Find(enrollmentId);
            _context.Enrollments.Remove(enrollment);
        }

        public async Task<Enrollment> GetEnrollmentByID(int enrollmentId)
        {
            //return _context.Enrollments.Find(enrollmentId);
            var enrollmentEntity = await _context.Enrollments.FirstOrDefaultAsync(m => m.EnrollmentID == enrollmentId);
            return enrollmentEntity;
            //return await _context.Enrollments.Include(e => e.Course).Include(e => e.Student).FirstOrDefaultAsync(m => m.EnrollmentID == enrollmentId);
        }

        public async Task<Enrollment> GetExistEnrollmentByID(int id)
        {
            return await _context.Enrollments.Include(e => e.Course).Include(e => e.Student).FirstOrDefaultAsync(m => m.EnrollmentID == id);
        }



        public async Task<IEnumerable<Enrollment>> GetEnrollments()
        {
            return await _context.Enrollments.Include(e => e.Course).Include(e => e.Student).ToListAsync();
        }

        public async void InsertEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
        }
        public async  Task<IEnumerable<int>> GetCourses()
        {
            var courseIds = await _context.Courses.Select(course => course.CourseID).ToListAsync();
            return courseIds;
        }
        public async Task<IEnumerable<int>> GetStudentIDs()
        {
            var studentIds = await _context.Students.Select(student => student.ID).ToListAsync();
            return studentIds;
        }

    }
   
}

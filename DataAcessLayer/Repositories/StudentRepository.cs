using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Data;
using PracticeProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly  SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByID(int studentId)
        {
            
            var studentEntity = await _context.Students
                     .Include(s => s.Enrollments)
                 .ThenInclude(e => e.Course)
             .FirstOrDefaultAsync(m => m.ID == studentId);
            return studentEntity;
            
        }

        public void InsertStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public void DeleteStudent(int studentID)
        {
            Student student = _context.Students.Find(studentID);
            _context.Students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        

    }
}

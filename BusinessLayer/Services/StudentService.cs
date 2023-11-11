using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentRepository.GetStudents();
        }

        public async Task<Student> GetStudentByID(int studentId)
        {
            return await _studentRepository.GetStudentByID(studentId);
        }
        public void DeleteStudent(int studentID)
        { 
            _studentRepository.DeleteStudent(studentID);
        }
        public void InsertStudent(Student student)
        {
             _studentRepository.InsertStudent(student);
        }

        public void Save()
        {
            _studentRepository.Save();
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);
        }
    }
}

using DataAcessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        public void DeleteEnrollment(int enrollmentId)
        {
            _enrollmentRepository.DeleteEnrollment(enrollmentId);
        }

       

        public async Task<Enrollment> GetEnrollmentByID(int enrollmentId)
        {
            return await _enrollmentRepository.GetEnrollmentByID(enrollmentId);
        }
        public async Task<Enrollment> GetExistEnrollmentByID(int id)
        {
            return await _enrollmentRepository.GetExistEnrollmentByID(id);
        }

        

        public async  Task<IEnumerable<Enrollment>> GetEnrollments()
        {
            return await _enrollmentRepository.GetEnrollments();
        }

        public void InsertEnrollment(Enrollment enrollment)
        {
            _enrollmentRepository.InsertEnrollment(enrollment);
        }
       

        public void Save()
        {
            _enrollmentRepository.Save();
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
              _enrollmentRepository.UpdateEnrollment(enrollment);
        }

        public async Task<List<Course>> GetCourses()
        {
            return  await _enrollmentRepository.GetCourses();
        }
        public async Task<List<Student>> GetStudentIDs()
        {
            return await _enrollmentRepository.GetStudentIDs();
        }

        



    }
}

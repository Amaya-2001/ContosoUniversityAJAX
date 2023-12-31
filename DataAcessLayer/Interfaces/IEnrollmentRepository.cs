﻿using PracticeProject.Entities;

namespace DataAcessLayer.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetEnrollments();
        Task<Enrollment> GetEnrollmentByID(int enrollmentId);
        void InsertEnrollment(Enrollment enrollment);
        void DeleteEnrollment(int enrollmentId);
        void UpdateEnrollment(Enrollment enrollment);
        Task<List<Course>> GetCourses();
        Task<List<Student>> GetStudentIDs();
        Task<Enrollment> GetExistEnrollmentByID(int id);
        void Save();

        
    }
}

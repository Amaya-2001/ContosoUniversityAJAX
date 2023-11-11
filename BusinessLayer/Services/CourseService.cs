using BusinessLayer.Interfaces;
using BusinessLayer.Repositories;
using DataAcessLayer.Interfaces;
using PracticeProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void DeleteCourse(int courseID)
        {
            _courseRepository.DeleteCourse(courseID);
        }

        public async Task<Course> GetCourseByID(int courseID)
        {
           return await _courseRepository.GetCourseByID(courseID);
            
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _courseRepository.GetCourses();
        }

        public void InsertCourse(Course course)
        {
            _courseRepository.InsertCourse(course);
        }

        public void Save()
        {
            _courseRepository.Save();
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.UpdateCourse(course);
        }
    }
}


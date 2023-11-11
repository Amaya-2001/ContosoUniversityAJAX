using PracticeProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourseByID(int courseID);
        void InsertCourse(Course course);
        void DeleteCourse(int courseID);
        void UpdateCourse(Course course);
        void Save();
    }
}

using AutoMapper;
using PracticeProject.Entities;
using PracticeProject.Models;

namespace PracticeProject.Helpers
{
    public static class CourseServiceCfg
    {
        private static IMapper _mapper;
        static CourseServiceCfg()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationMapper>();
            });

            _mapper = config.CreateMapper();
        }

        public static List<CourseModel> ToCourseList(IEnumerable<Course> courses)
        {
            return _mapper.Map<List<CourseModel>>(courses);
        }
        public static CourseModel ToGetCourse(Course course)
        {
            return _mapper.Map<CourseModel>(course);
        }
        public static Course ToCreateCourse(CourseModel courseModel)
        {
            return _mapper.Map<Course>(courseModel);
        }
        public static Course UpdateCourse(CourseModel courseModel, Course course)
        {
            var updateCourse = _mapper.Map(courseModel, course);
            return updateCourse;
        }



    }

}



   
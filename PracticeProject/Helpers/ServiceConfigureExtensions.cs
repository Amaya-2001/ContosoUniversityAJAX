using AutoMapper;
using PracticeProject.Entities;
using PracticeProject.Models;

namespace PracticeProject.Helpers
{
    public static class ServiceConfigureExtensions
    {
        private static IMapper _mapper;

        static ServiceConfigureExtensions()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationMapper>();
            });

            _mapper = config.CreateMapper();
        }
        public static List<StudentModel> ToStudentModelList(IEnumerable<Student> students)
        {
            return _mapper.Map<List<StudentModel>>(students);
        }

        public static StudentDetailsModel ToStudentModel(Student student)
        {
            return _mapper.Map<StudentDetailsModel>(student);
        }

        public static Student ToCreateStudent(StudentModel studentModel)
        {
            return _mapper.Map<Student>(studentModel);
        }

        public static Student UpdateStudent(StudentDetailsModel studentModel, Student student)
        {
            var updateStudent = _mapper.Map(studentModel, student);
            return updateStudent;
        }


    }
    

    
}

using AutoMapper;
using DataAcessLayer.Entities;
using PracticeProject.Entities;
using PracticeProject.Models;

namespace PracticeProject.Helpers
{
    public class ApplicationMapper : Profile
    {

        public ApplicationMapper() {
            //CreateMap<StudentModel, Student>().ForMember(s => s.EnrollmentDate, option => option.Ignore());

            
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<Student,StudentDetailsModel>().ReverseMap();
            CreateMap<Student,StudentEditModel>().ReverseMap();
            CreateMap<Course, CourseModel>().ReverseMap();
            CreateMap<Enrollment, EnrollmentModel>().ReverseMap();
            CreateMap<UserSignUp, UserSignUpModel>().ReverseMap();
        }
    }
}

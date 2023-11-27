using AutoMapper;
using DataAcessLayer.Entities;
using PracticeProject.Entities;
using PracticeProject.Models;

namespace PracticeProject.Helpers
{
   public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Student, StudentModel>().ReverseMap();
        CreateMap<Student, StudentDetailsModel>().ReverseMap();
        CreateMap<Student, StudentEditModel>().ReverseMap();
        CreateMap<Course, CourseModel>().ReverseMap();
        CreateMap<Enrollment, EnrollmentModel>().ReverseMap();
        CreateMap<UserSignUp, UserSignUpModel>().ReverseMap();
        
        CreateMap<UserLoginModel, UserSignUp>()
            .ForMember(dest => dest.UserID, opt => opt.Ignore())
            .ForMember(dest => dest.UserName, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
    }
}

}

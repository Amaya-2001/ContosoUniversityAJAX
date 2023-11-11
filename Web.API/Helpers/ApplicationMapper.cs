using AutoMapper;
using PracticeProject.Entities;
using Web.API.Models;

namespace Web.API.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            //CreateMap<StudentModel, Student>().ForMember(s => s.EnrollmentDate, option => option.Ignore());
            CreateMap<Student, StudentModel>().ReverseMap();
        }
    }
}

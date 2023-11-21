using AutoMapper;
using DataAcessLayer.Entities;
using PracticeProject.Models;

namespace PracticeProject.Helpers
{
    public static class MappingUserApplication
    {
        public static IMapper _mapper;
        static MappingUserApplication()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationMapper>();
            });

            _mapper = config.CreateMapper();
        }
        public static UserSignUp ToCreateUser(UserSignUpModel signUpModel)
        {
            return _mapper.Map<UserSignUp>(signUpModel);
        }
    }
}

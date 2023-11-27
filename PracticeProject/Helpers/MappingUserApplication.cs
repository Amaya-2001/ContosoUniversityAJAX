using AutoMapper;
using DataAcessLayer.Entities;
using PracticeProject.Models;

namespace PracticeProject.Helpers
{
    public static class MappingUserApplication
    {
        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationMapper>();
            });

            return config.CreateMapper();
        }

        public static UserSignUp ToCreateUser(UserSignUpModel signUpModel)
        {
            var mapper = GetMapper();
            return mapper.Map<UserSignUp>(signUpModel);
        }

        public static UserSignUp ToGetLoginUser(UserLoginModel userLoginModel)
        {
           
            var mapper = GetMapper();
            return mapper.Map<UserSignUp>(userLoginModel);
            
        }
    }
}

using AutoMapper;
using PracticeProject.Entities;
using PracticeProject.Models;

namespace PracticeProject.Helpers
{
    public class EnrollmentServicesCfg
    {
        private static IMapper _mapper;

        static EnrollmentServicesCfg()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationMapper>();
            });

            _mapper = config.CreateMapper();
        }
        public static List<EnrollmentModel> ToEnrollmentList(IEnumerable<Enrollment> enrollments)
        {
            return _mapper.Map<List<EnrollmentModel>>(enrollments);
        }

        public static EnrollmentModel ToEnrollmentDetails(Enrollment enrollment)
        {
            return _mapper.Map<EnrollmentModel>(enrollment);
        }

        public static Enrollment ToCreateEnrollment(EnrollmentModel enrollmentModel)
        {
            return _mapper.Map<Enrollment>(enrollmentModel);
        }

        public static Enrollment UpdateEnrollment(EnrollmentModel enrollmentModel, Enrollment enrollment)
        {
            var updateEnrollment = _mapper.Map(enrollmentModel, enrollment);
            return updateEnrollment;
        }


    }

}


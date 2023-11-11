﻿using PracticeProject.Models;

namespace Web.API.Models
{
    public class StudentDetailsModel
    {

        public int ID { get; set; }
        public string? LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<EnrollmentModel> Enrollments { get; set; }
    }
}

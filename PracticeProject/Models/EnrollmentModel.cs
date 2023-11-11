using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace PracticeProject.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class EnrollmentModel
    {
        
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public CourseModel? Course { get; set; }
        public StudentModel? Student { get; set; }
    }
}

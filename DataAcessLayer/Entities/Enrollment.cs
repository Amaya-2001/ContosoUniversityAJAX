using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Entities
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]

        public Student Student { get; set; }

        public Course Course { get; set; }

    }
}

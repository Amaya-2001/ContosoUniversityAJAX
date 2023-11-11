using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeProject.Entities
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
        
    }
}

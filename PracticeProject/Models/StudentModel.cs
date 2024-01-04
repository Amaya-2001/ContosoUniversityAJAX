using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models
{
    public class StudentModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

       
    }
}

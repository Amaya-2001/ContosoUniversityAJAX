using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeProject.Models
{
    public class CourseModel
    {
       
        public int CourseID { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }

        
    }
}

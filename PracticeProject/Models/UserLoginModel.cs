using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models
{
    public class UserLoginModel
    {
        [Required]
        [StringLength(25)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}

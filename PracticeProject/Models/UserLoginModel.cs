using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models
{
    public class UserLoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}

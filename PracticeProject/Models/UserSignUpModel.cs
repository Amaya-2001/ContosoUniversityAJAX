using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models
{
    public class UserSignUpModel
    {

        
        public  int UserID { get; set; }


        [Required]
        [StringLength(25)]
        [EmailAddress]
        public  string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength =3)]
        [RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "Invalid UserName format.")]
        public  string UserName { get; set; }

        [Required]
        [StringLength (8, MinimumLength =6)]
        [DataType(DataType.Password)]
        public  string Password { get; set; }
    }
}

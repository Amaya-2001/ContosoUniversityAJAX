using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAcessLayer.Entities
{
    public class UserSignUp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public  string Email { get; set; } = string.Empty;
        public  string UserName { get; set; } = string.Empty.ToString();
        public string Password { get; set; } = string.Empty;
    }
}

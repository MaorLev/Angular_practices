using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Data.Entities
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [Column("UserId")]
        public int Id { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }
        [Required]
        [Column("Password")]
        

        public string Password { get; set; }
    }
}

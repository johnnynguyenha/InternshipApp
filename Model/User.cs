using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Users")]
    public class User
    {
            [Key]
            public int UserId { get; set; } // assumed as the primary key because has the name of the class + id in it
            [Required]
            [MaxLength(100)]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            [MaxLength(10)]
            public string Role { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }

        }
    }

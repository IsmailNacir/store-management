using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.Models
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage ="First Name is required !")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name is required !")]
        public string LastName { get; set; }
        public bool IsAuthor { get; set; } = false;
        [NotMapped]
        public string FullName => FirstName + " " + LastName;

    }
}

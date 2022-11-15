using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "Password must be beteween 6 et 20 characters !")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;

        [Display(Name ="Remember Me")]
        public bool Remember { get; set; }

    }
}

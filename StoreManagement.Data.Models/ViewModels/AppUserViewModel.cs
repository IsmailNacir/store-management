using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.Models.ViewModels
{
    public class AppUserViewModel
    {
        [Required(ErrorMessage = "First Name is required !")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required !")]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "The e-mail must be in the correct format")]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "Password must be beteween 6 et 20 characters !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Passeword must match")]
        public string ConfirmPassword { get; set; }


    }
}

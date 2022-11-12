using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StoreManagement.Data.Models.ViewModels
{
    public class CategoryViewModel
    {
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Categry name is required !")]
        [StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessage = "Category Name must be between 3 and 30 char")]
        public string Libelle { get; set; } = string.Empty;

    }
}

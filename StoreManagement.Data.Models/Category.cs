using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.Models
{
    public class Category
    {
        public Guid? CategoryId { get; set; }
        [StringLength(maximumLength:30, MinimumLength =3, ErrorMessage ="Category Name must be between 3 and 30 char")]
        public string Libelle { get; set; } = string.Empty;

    }
}

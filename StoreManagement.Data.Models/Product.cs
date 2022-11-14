using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.Models
{
    public class Product
    {
        [Key]
        public Guid? ProductId { get; set; }

        [Display(Name ="Product Name")]
        [StringLength(maximumLength:30, MinimumLength =3, ErrorMessage = "Product Name must be between 3 and 30 char")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Product Description")]
        [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "Product Description must be between 3 and 30 char")]
        public string ProductDescription { get; set; } = string.Empty;

        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }

        [Display(Name = "Product Promotion")]
        [Required(ErrorMessage = "Product Promotion is required !")]
        public bool ProductPromotion { get; set; }

        [Display(Name = "Purchase date")]
        public DateTime DateAchat { get; set; }
        public Guid? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

    }
}

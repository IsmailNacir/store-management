using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.Models
{
    public class Category
    {
        public Guid? CategoryId { get; set; }
        public string Libelle { get; set; } = string.Empty;

    }
}

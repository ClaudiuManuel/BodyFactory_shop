using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bodyfactory.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Product Title")]
        public string Title { get; set; }
        [Required, StringLength(100, MinimumLength = 3)]
        public string Manufacturer { get; set; }
        [Range(1, 9999)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage ="Va rugam introduceti o aroma valida(doar litere)"), Required,StringLength(50, MinimumLength = 3)]
        public string Flavor { get; set; }

        public int DistributorID { get; set; }

        public Distributor Distributor { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}

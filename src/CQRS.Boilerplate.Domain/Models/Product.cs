using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Domain.Models
{
    public class Product : BaseEntity<Guid>
    {

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string SKU { get; set; }

        public Stock Stock { get; set; }

        public Product()
        {

        }

        public Product(string name, string sku, Stock stock)
        {
            Name = name;
            SKU = sku;
            Stock = stock;
        }
    }
}

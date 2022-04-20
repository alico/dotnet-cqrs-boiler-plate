using CQRS.Boilerplate.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Domain.Models
{
    public class Product : BaseEntity<Guid>, IHasDomainEvent
    {

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string SKU { get; set; }

        public Stock Stock { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public Product()
        {

        }
        public Product(string name, string sku)
        {
            Name = name;
            SKU = sku;
        }
    }
}

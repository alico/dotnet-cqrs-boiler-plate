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
    public class Customer : BaseEntity<Guid>, IHasDomainEvent
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public IList<Order> Orders { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public Customer()
        {

        }
        public Customer(string name, string email, IList<Order> orders)
        {
            Name = name;
            Email = email;
            Orders = orders;
        }
    }
}

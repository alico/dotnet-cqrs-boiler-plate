using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Domain.Common
{
    public interface IHasDomainEvent
    {
        [NotMapped]
        public List<DomainEvent> DomainEvents { get; set; }
    }
}

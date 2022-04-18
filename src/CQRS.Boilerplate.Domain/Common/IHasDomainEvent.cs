using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Domain.Common
{
    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }
}

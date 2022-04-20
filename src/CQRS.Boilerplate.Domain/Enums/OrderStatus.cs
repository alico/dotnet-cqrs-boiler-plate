using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Domain.Enums
{
    public enum OrderStatus
    {
        None = 0,
        Placed = 1,
        Approved = 2,
        Declined = 3,
        Dispatched = 4
    }
}

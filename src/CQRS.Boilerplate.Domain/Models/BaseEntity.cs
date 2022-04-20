using CQRS.Boilerplate.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Domain.Models
{
    public abstract class BaseEntity<T> : BaseEntity where T : struct
    {
        public virtual T Id { get; set; }
    }

    public abstract class BaseEntity
    {
        public virtual DateTime? LastModifyDate { get; set; }

        public virtual DateTime CreationDate { get; set; }
    }
}

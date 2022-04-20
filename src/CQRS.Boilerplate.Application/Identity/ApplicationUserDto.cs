using CQRS.Boilerplate.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Application.Identity.Models;
public class ApplicationUserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }

    public DateTime CreationDate { get; set; }
    public DateTime LastmodifyDate { get; set; }
}



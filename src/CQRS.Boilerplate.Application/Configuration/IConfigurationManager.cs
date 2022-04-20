using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Application.Commands.Configuration
{
    public interface IConfigurationManager
    {
        public string DBConnectionString { get; }
    }
}

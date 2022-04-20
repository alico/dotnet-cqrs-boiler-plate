using CQRS.Boilerplate.Application.Common.Models;
using CQRS.Boilerplate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Application.Common.Interfaces;
public interface IIdentityService
{
    Task<string> GetUserNameAsync(Guid userId);

    Task<bool> IsInRoleAsync(Guid userId, string role);

    Task<bool> AuthorizeAsync(Guid userId, string policyName);

    Task<(Result, Guid)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(Guid userId);
}

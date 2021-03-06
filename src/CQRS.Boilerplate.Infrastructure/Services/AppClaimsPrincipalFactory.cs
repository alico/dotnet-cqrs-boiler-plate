using CQRS.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Infrastructure.Services
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager
            , RoleManager<ApplicationRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
        new Claim(ClaimTypes.Name, user.UserName)
    });
            }

            if (!string.IsNullOrWhiteSpace(user.Email))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                    new Claim(ClaimTypes.Email, user.Email),
                    });
            }

            return principal;
        }
    }
}

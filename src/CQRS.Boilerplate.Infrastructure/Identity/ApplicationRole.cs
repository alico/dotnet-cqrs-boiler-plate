using Microsoft.AspNetCore.Identity;

namespace CQRS.Infrastructure.Identity;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole()
    {

    }

    public ApplicationRole(string name) : base(name)
    {

    }
}
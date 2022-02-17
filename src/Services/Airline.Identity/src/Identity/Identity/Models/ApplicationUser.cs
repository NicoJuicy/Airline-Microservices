using Microsoft.AspNetCore.Identity;

namespace Identity.Identity.Models;

public class ApplicationUser: IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

using Microsoft.AspNetCore.Identity;

namespace Esess.AuthAPI.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}

using Esess.AuthAPI.Models;

namespace Esess.AuthAPI.Service.IService;

public interface IJwtTokenGenerator
{
    string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
}

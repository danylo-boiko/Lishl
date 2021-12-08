using Lishl.Authentication.Responses;
using Lishl.Core.Models;

namespace Lishl.Authentication.Services
{
    public interface IAuthenticationService
    {
        AuthResponse Authenticate(User user);
    }
}
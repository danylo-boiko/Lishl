using Lishl.Authentication.Responses;
using Lishl.Core.Models;

namespace Lishl.Authentication.AuthenticationService
{
    public interface IAuthenticationService
    {
        AuthResponse Authenticate(User user);
    }
}
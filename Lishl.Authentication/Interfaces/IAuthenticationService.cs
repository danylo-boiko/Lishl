using Lishl.Authentication.Responses;
using Lishl.Core.Models;

namespace Lishl.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        AuthResponse Authenticate(User user);
    }
}
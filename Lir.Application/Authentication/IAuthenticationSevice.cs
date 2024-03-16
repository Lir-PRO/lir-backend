using Lir.Application.Authentication.ImputTypes;
using Lir.Application.Authentication.Payload;

namespace Lir.Application.Authentication
{
    public interface IAuthenticationService
    {
        Task<LoginUserPayload> Login(LoginInputType input);
        Task<RegisterUserPayload> Register(RegisterInputType input);
    }
}

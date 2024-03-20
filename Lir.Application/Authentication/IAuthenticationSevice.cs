using Lir.Application.Authentication.ImputTypes;
using Lir.Application.Authentication.Payload;

namespace Lir.Application.Authentication
{
    public interface IAuthenticationService
    {
        Task<LoginUserPayload> Login(LoginUserInput input);
        Task<RegisterUserPayload> Register(RegisterUserInput userInput);
    }
}

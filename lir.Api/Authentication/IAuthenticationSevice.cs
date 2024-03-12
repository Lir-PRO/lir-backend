using Lir.Api.GraphQL.InputTypes;
using Lir.Api.GraphQL.Payload;
using Lir.Core.Models;

namespace Lir.Api.Authentication
{
    public interface IAuthenticationService
    {
        Task<LoginUserPayload> Login(LoginInputType input);
        Task<RegisterUserPayload> Register(RegisterInputType input);
    }
}

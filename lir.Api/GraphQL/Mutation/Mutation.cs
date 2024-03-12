using Lir.Api.Authentication;
using Lir.Api.GraphQL.InputTypes;
using Lir.Api.GraphQL.Payload;

namespace Lir.Api.GraphQL.Mutation
{
    public class Mutation
    {
        public async Task<LoginUserPayload> LoginUser(string email, string password, IAuthenticationService authenticationService)
        {
            var input = new LoginInputType()
            {
                Email = email,
                Password = password
            };
            return await authenticationService.Login(input);
        }

        public async Task<RegisterUserPayload> RegisterUser(string email, string username, string name, string bio, string password, string passwordConfirmation, IAuthenticationService authenticationService)
        {
            var input = new RegisterInputType()
            {
                Email = email,
                Name = name,
                Username = username,
                Password = password,
                Bio = bio,
                ConfirmPassword = passwordConfirmation
            };
            return await authenticationService.Register(input);
        }
    }
}

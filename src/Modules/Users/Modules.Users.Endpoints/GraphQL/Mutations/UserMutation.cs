using HotChocolate;
using MediatR;
using Modules.Users.Application.Common.Models;
using Modules.Users.Application.Users.Commands.AddUser;
using Modules.Users.Application.Users.Commands.Login;

namespace Modules.Users.Endpoints.GraphQL.Mutations;

public class UserMutation
{
    public async Task<string> AddUser(AddUserInput input, [Service] ISender mediatr)
    {
        return await mediatr.Send(new AddUserCommand(input));
    }

    public async Task<string> Login(string email, string password, [Service] ISender mediatr)
    {
        return await mediatr.Send(new LoginCommand(email, password));
    }
}
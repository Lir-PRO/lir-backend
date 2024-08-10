using HotChocolate;
using MediatR;
using Modules.Users.Application.Common;
using Modules.Users.Application.Common.Input;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Application.Users.Commands.AddUser;
using Modules.Users.Application.Users.Commands.DeleteUser;
using Modules.Users.Application.Users.Commands.Login;
using Modules.Users.Application.Users.Commands.UpdateUser;

namespace Modules.Users.Endpoints.GraphQL.Mutations;

public class UserMutation
{
    public async Task<Response<string>> AddUser(AddUserInput input, [Service] ISender mediatr)
    {
        return await mediatr.Send(new AddUserCommand(input));
    }

    public async Task<Response<UserPayload>> UpdateUser(UpdateUserInput input, [Service] ISender mediatr)
    {
        return await mediatr.Send(new UpdateUserCommand(input));
    }

    public async Task<Response<string>> Login(string email, string password, [Service] ISender mediatr)
    {
        return await mediatr.Send(new LoginCommand(email, password));
    }

    public async Task<Response<bool>> DeleteUser(string id, [Service] ISender mediatr)
    {
        return await mediatr.Send(new DeleteUserCommand(id));
    }
}
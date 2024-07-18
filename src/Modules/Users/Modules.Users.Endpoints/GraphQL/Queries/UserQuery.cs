using HotChocolate;
using HotChocolate.Types;
using MediatR;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Application.Users.Queries.GetUserById;
using Modules.Users.Application.Users.Queries.GetUserByUsername;
using Modules.Users.Application.Users.Queries.GetUsers;

namespace Modules.Users.Endpoints.GraphQL.Queries;

public class UserQuery
{
    public async Task<UserPayload> GetUserById(string id, [Service] ISender mediatr)
    {
        return await mediatr.Send(new GetUserByIdQuery(id));
    }

    public async Task<UserPayload> GetUserByUsername(string username, [Service] ISender mediatr)
    {
        return await mediatr.Send(new GetUserByUsernameQuery(username));
    }

    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<UserPayload>> GetUsers([Service] ISender mediatr)
    {
        return await mediatr.Send(new GetUsersQuery());
    }
}
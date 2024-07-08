using HotChocolate;
using HotChocolate.Types;
using MediatR;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Application.Users.Queries.GetUserById;
using Modules.Users.Application.Users.Queries.GetUserByUsername;
using Modules.Users.Application.Users.Queries.GetUsers;
using Modules.Users.Application.Users.Queries.GetUsersSubscriptions;

namespace Modules.Users.Endpoints.GraphQL.Queries;

public class UserQuery
{
    public async Task<UserPayload> GetUserById(string id, [Service] ISender mediatr)
    {
        return await mediatr.Send(new GetUserByIdQuery(id));
    }

    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<UserPayload>> GetUsers([Service] ISender mediatr)
    {
        return await mediatr.Send(new GetUsersQuery());
    }

    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<UserPayload>> GetUsersSubscribers(string id, [Service] ISender mediatr)
    {
        return await mediatr.Send(new GetUsersSubscribersQuery(id));
    }

    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<UserPayload>> GetUsersSubscriptions(string id, [Service] ISender mediatr)
    {
        return await mediatr.Send(new GetUsersSubscriptionsQuery(id));
    }
}
using HotChocolate;
using MediatR;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Application.Users.Queries.GetUserById;

namespace Modules.Users.Endpoints.GraphQL.Queries;

public class UserQuery
{
    public async Task<UserPayload> GetUserById(string id, [Service] ISender mediatr)
    {
        return await mediatr.Send(new GetUserByIdQuery(id));
    }
}
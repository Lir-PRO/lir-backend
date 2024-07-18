using HotChocolate;
using HotChocolate.Types;
using MediatR;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Application.Subscription.Queries.GetSubscribersByUserId;
using Modules.Users.Application.Subscription.Queries.GetSubscriptionsByUserId;

namespace Modules.Users.Endpoints.GraphQL.Queries;

public class SubscriptionQuery
{

    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<UserPayload>> GetSubscribersByUserId(string userId, [Service] ISender mediatr)
    {
        return await mediatr.Send(new GetSubscribersByUserIdQuery(userId));
    }

    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<UserPayload>> GetSubscriptionsByUserId(string userId, [Service] ISender mediatr)
    {
        return await mediatr.Send(new GetSubscriptionsByUserIdQuery(userId));
    }
}
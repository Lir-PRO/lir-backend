using HotChocolate;
using MediatR;
using Modules.Users.Application.Subscription.Commands.AddSubscription;
using Modules.Users.Application.Subscription.Commands.DeleteSubscription;

namespace Modules.Users.Endpoints.GraphQL.Mutations;

public class SubscriptionMutation
{
    public async Task<bool> AddSubscription(string userId, string subscriberId, [Service] ISender mediatr)
    {
        return await mediatr.Send(new AddSubscriptionCommand(userId, subscriberId));
    }

    public async Task<bool> DeleteSubscription(string userId, string subscriberId, [Service] ISender mediatr)
    {
        return await mediatr.Send(new DeleteSubscriptionCommand(userId, subscriberId));
    }
}
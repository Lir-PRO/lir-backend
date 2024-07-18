using MediatR;

namespace Modules.Users.Application.Subscription.Commands.AddSubscription;

public record AddSubscriptionCommand(string UserId, string SubscriberId) : IRequest<bool>;
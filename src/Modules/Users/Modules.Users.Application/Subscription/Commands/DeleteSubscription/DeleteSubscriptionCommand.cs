using MediatR;

namespace Modules.Users.Application.Subscription.Commands.DeleteSubscription;

public record DeleteSubscriptionCommand(string UserId, string SubscriberId) : IRequest<bool>;
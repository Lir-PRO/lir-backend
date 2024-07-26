using MediatR;

namespace Modules.Users.Application.Subscriptions.Commands.DeleteSubscription;

public record DeleteSubscriptionCommand(string UserId, string SubscriberId) : IRequest<bool>;
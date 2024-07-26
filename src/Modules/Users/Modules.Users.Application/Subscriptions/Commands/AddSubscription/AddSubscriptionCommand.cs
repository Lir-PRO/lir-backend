using MediatR;

namespace Modules.Users.Application.Subscriptions.Commands.AddSubscription;

public record AddSubscriptionCommand(string UserId, string SubscriberId) : IRequest<bool>;
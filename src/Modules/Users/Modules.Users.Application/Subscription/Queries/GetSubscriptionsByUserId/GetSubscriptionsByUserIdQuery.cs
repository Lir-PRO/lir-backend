using MediatR;
using Modules.Users.Application.Common.Payload;

namespace Modules.Users.Application.Subscription.Queries.GetSubscriptionsByUserId;

public record GetSubscriptionsByUserIdQuery(string UserId) : IRequest<IQueryable<UserPayload>>;
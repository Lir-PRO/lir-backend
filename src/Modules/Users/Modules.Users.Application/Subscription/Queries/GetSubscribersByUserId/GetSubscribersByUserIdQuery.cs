using MediatR;
using Modules.Users.Application.Common.Payload;

namespace Modules.Users.Application.Subscription.Queries.GetSubscribersByUserId;

public record GetSubscribersByUserIdQuery(string UserId) : IRequest<IQueryable<UserPayload>>;
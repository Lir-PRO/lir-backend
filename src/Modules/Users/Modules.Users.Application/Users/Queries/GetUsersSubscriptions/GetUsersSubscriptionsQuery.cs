using MediatR;
using Modules.Users.Application.Common.Payload;

namespace Modules.Users.Application.Users.Queries.GetUsersSubscriptions;

public record GetUsersSubscriptionsQuery(string Id) : IRequest<IQueryable<UserPayload>>;
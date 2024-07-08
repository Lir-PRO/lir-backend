using MediatR;
using Modules.Users.Application.Common.Payload;

namespace Modules.Users.Application.Users.Queries.GetUsers;

public record GetUsersQuery() : IRequest<IQueryable<UserPayload>>;
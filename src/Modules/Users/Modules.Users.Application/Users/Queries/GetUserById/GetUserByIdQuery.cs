using MediatR;
using Modules.Users.Application.Common.Payload;

namespace Modules.Users.Application.Users.Queries.GetUserById;

public record GetUserByIdQuery(string Id) : IRequest<UserPayload>;
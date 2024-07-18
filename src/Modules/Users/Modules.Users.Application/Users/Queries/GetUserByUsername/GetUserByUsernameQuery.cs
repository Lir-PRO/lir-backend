using MediatR;
using Modules.Users.Application.Common.Payload;

namespace Modules.Users.Application.Users.Queries.GetUserByUsername;

public record GetUserByUsernameQuery(string Username) : IRequest<UserPayload>;
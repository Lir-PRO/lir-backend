using MediatR;
using Modules.Users.Application.Common;

namespace Modules.Users.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(string Id) : IRequest<Response<bool>>;
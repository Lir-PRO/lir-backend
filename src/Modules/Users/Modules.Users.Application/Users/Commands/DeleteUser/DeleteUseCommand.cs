using MediatR;

namespace Modules.Users.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(string Id) : IRequest<bool>;
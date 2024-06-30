using MediatR;

namespace Modules.Users.Application.Users.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<string>;
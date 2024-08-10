using MediatR;
using Modules.Users.Application.Common;

namespace Modules.Users.Application.Users.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<Response<string>>;
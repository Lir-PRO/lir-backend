using MediatR;
using Modules.Users.Application.Common.Input;

namespace Modules.Users.Application.Users.Commands.AddUser;

public record AddUserCommand(AddUserInput Input) : IRequest<string>;
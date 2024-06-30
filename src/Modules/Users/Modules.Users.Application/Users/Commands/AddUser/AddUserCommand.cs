using MediatR;
using Modules.Users.Application.Common.Models;

namespace Modules.Users.Application.Users.Commands.AddUser;

public record AddUserCommand(AddUserInput Input) : IRequest<string>;
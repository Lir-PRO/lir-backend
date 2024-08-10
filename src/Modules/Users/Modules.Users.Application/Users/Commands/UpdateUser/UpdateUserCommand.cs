using MediatR;
using Modules.Users.Application.Common;
using Modules.Users.Application.Common.Input;
using Modules.Users.Application.Common.Payload;

namespace Modules.Users.Application.Users.Commands.UpdateUser;

public record UpdateUserCommand(UpdateUserInput Input) : IRequest<Response<UserPayload>>;
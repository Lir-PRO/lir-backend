using Common.Events;
using MassTransit;
using MediatR;
using Modules.Users.Application.Common.Errors;
using Modules.Users.Application.Common.Interfaces;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Application.Users.Commands.DeleteUser;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, global::Common.Response<bool>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IAuth0Service _auth0Service;

    public DeleteUserCommandHandler(IUserRepository userRepository, IPublishEndpoint publishEndpoint, IAuth0Service auth0Service)
    {
        _userRepository = userRepository;
        _publishEndpoint = publishEndpoint;
        _auth0Service = auth0Service;
    }

    public async Task<global::Common.Response<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _auth0Service.DeleteUser(request.Id))
            {
                return global::Common.Response<bool>.Failure(UserErrors.DeleteUserFailureAuth0);
            }

            var result = await _userRepository.DeleteAsync(request.Id, cancellationToken);

            if (result)
            {
                await _publishEndpoint.Publish(new UserDeletedEvent(request.Id));
            }

            return result
                ? global::Common.Response<bool>.Success(result)
                : global::Common.Response<bool>.Failure(UserErrors.DeleteUserFailure);
        }
        catch (Exception ex)
        {
            return global::Common.Response<bool>.Failure(UserErrors.DeleteUserFailure);
        }
    }
}
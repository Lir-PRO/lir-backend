using Common.Events;
using MassTransit;
using MediatR;
using Modules.Users.Application.Common.Errors;
using Modules.Users.Application.Common.Interfaces;
using Modules.Users.Domain.Entities;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Application.Users.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, global::Common.Response<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuth0Service _auth0Service;
    private readonly IPublishEndpoint _publishEndpoint;

    public AddUserCommandHandler(IUserRepository userRepository, 
        IAuth0Service auth0Service,
        IPublishEndpoint publishEndpoint)
    {
        _userRepository = userRepository;
        _auth0Service = auth0Service; 
        _publishEndpoint = publishEndpoint;
    }

    public async Task<global::Common.Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (await _userRepository.IsEmailAlreadyUsed(request.Input.Email))
            {
                return global::Common.Response<string>.Failure(UserErrors.EmailIsAlreadyUsed);
            }

            if (await _userRepository.IsUsernameTaken(request.Input.Username))
            {
                return global::Common.Response<string>.Failure(UserErrors.UsernameIsTaken);
            }

            var auth0UserId = await _auth0Service.SignupUser(request.Input.Email, request.Input.Password);

            var newUser = new User
            {
                Id = auth0UserId,
                Email = request.Input.Email,
                Name = request.Input.Name,
                Bio = request.Input.Bio,
                Username = request.Input.Username,
                ProfilePictureBase64 = request.Input.ProfilePictureBase64
            };

            await _userRepository.AddAsync(newUser, cancellationToken);
            await _publishEndpoint.Publish(new UserCreatedEvent(newUser.Id));

            return global::Common.Response<string>.Success(auth0UserId);
        }
        catch (Exception ex)
        {
            return global::Common.Response<string>.Failure(UserErrors.AddUserFailure);
        }
    }
}
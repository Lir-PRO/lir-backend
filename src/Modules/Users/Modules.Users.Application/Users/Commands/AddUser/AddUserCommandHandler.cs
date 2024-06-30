using MediatR;
using Modules.Users.Application.Common.Interfaces;
using Modules.Users.Domain.Entities;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Application.Users.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuth0Service _auth0Service;

    public AddUserCommandHandler(IUserRepository userRepository, IAuth0Service auth0Service)
    {
        _userRepository = userRepository;
        _auth0Service = auth0Service;
    }

    public async Task<string> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var auth0UserId = await _auth0Service.SignupUser(request.Input.Email, request.Input.Password);

        var newUser = new User
        {
            Id = auth0UserId,
            Email = request.Input.Email,
            Name = request.Input.Name,
            Bio = request.Input.Bio,
            ProfilePictureBase64 = request.Input.ProfilePictureBase64
        };

        await _userRepository.AddAsync(newUser, cancellationToken);

        return newUser.Id;
    }
}
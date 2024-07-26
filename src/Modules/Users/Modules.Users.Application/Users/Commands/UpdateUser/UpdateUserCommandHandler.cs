using AutoMapper;
using MediatR;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserPayload>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserPayload> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Input == null)
        {
            throw new ArgumentNullException(nameof(request), "Request or input cannot be null");
        }

        var user = await _userRepository.GetByIdAsync(request.Input.Id, cancellationToken);
        if (user == null)
        {
            throw new InvalidOperationException($"User with ID {request.Input.Id} not found");
        }

        if (string.IsNullOrWhiteSpace(request.Input.Username))
        {
            throw new ArgumentException("Username is required", nameof(request.Input.Username));
        }

        user.Username = request.Input.Username;
        user.Bio = request.Input.Bio;
        user.Name = request.Input.Name;
        user.ProfilePictureBase64 = request.Input.ProfilePictureBase64;

        try
        {
            await _userRepository.UpdateAsync(user.Id, user, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the user", ex);
        }

        return _mapper.Map<UserPayload>(user);
    }
}
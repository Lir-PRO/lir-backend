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
        var user = await _userRepository.GetByIdAsync(request.Input.Id, cancellationToken);

        user.Username = request.Input.Username;
        user.Bio = request.Input.Bio;
        user.Name = request.Input.Name;

        await _userRepository.UpdateAsync(user.Id, user, cancellationToken);

        return _mapper.Map<UserPayload>(user);
    }
}
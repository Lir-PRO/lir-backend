using AutoMapper;
using MediatR;
using Modules.Users.Application.Common;
using Modules.Users.Application.Common.Errors;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<UserPayload>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Response<UserPayload>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null || request.Input == null)
            {
                return Response<UserPayload>.Failure(UserErrors.InputIsNull);
            }

            var user = await _userRepository.GetByIdAsync(request.Input.Id, cancellationToken);
            if (user == null)
            {
                return Response<UserPayload>.Failure(UserErrors.NotFound);
            }

            user.Username = request.Input.Username;
            user.Bio = request.Input.Bio;
            user.Name = request.Input.Name;
            user.ProfilePictureBase64 = request.Input.ProfilePictureBase64;

            await _userRepository.UpdateAsync(user.Id, user, cancellationToken);

            var userPayload = _mapper.Map<UserPayload>(user);

            return Response<UserPayload>.Success(userPayload);
        }
        catch (Exception ex)
        {
            return Response<UserPayload>.Failure(UserErrors.UpdateUserFailure);
        }
    }
}
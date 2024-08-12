using Common;
using MediatR;
using Modules.Users.Application.Common.Interfaces;

namespace Modules.Users.Application.Users.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Response<string>>
{
    private readonly IAuth0Service _auth0Service;

    public LoginCommandHandler(IAuth0Service auth0Service)
    {
        _auth0Service = auth0Service;
    }

    public async Task<Response<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var token = await _auth0Service.LoginUser(request.Email, request.Password);

        return Response<string>.Success(token);
    }
}
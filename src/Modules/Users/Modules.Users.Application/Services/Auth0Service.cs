using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.Extensions.Options;
using Modules.Users.Application.Common.Interfaces;
using Modules.Users.Application.Common.Models;

namespace Modules.Users.Application.Services;

public class Auth0Service : IAuth0Service
{
    private readonly Auth0Settings _auth0Settings;

    public Auth0Service(IOptions<Auth0Settings> auth0Settings)
    {
        _auth0Settings = auth0Settings.Value;
    }

    public async Task<string> SignupUser(string email, string password)
    {
        var auth0Client = new AuthenticationApiClient(new Uri($"https://{_auth0Settings.Domain}/"));
        var signupRequest = new SignupUserRequest
        {
            ClientId = _auth0Settings.ClientId,
            Email = email,
            Password = password,
            Connection = "Username-Password-Authentication"
        };

        var signupResponse = await auth0Client.SignupUserAsync(signupRequest);
        return signupResponse.Id;
    }

    public async Task<string> LoginUser(string email, string password)
    {
        var auth0Client = new AuthenticationApiClient(new Uri($"https://{_auth0Settings.Domain}/"));
        var tokenRequest = new ResourceOwnerTokenRequest
        {
            ClientId = _auth0Settings.ClientId,
            ClientSecret = _auth0Settings.ClientSecret,
            Realm = "Username-Password-Authentication",
            Scope = "openid profile",
            Username = email,
            Password = password
        };

        var tokenResponse = await auth0Client.GetTokenAsync(tokenRequest);
        return tokenResponse.AccessToken;
    }
}
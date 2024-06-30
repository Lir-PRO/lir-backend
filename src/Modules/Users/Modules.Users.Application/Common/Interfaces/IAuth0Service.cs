namespace Modules.Users.Application.Common.Interfaces;

public interface IAuth0Service
{
    Task<string> SignupUser(string email, string password);
    Task<string> LoginUser(string email, string password);
}
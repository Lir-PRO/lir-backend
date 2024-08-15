namespace Modules.Chats.Domain.Interfaces;

public interface IUserRepository
{
    public Task<bool> UserExists(string id);
}
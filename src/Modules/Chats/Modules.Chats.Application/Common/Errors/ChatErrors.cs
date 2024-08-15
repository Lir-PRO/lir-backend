using Common;

namespace Modules.Chats.Application.Common.Errors;

public static class ChatErrors
{
    public static readonly Error UserNotFound = new(
        "Chats.UserNotFound",
        "User with given Id not found");
}
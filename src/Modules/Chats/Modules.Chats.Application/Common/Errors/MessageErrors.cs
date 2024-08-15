
using Common;

namespace Modules.Chats.Application.Common.Errors;

public static class MessageErrors
{
    public static readonly Error EmptyMessage = new(
        "Messages.EmptyMessage",
        "Can not send an empty message");
}
using Common;

namespace Modules.Posts.Application.Common.Errors;

public static class PostErrors
{
    public static readonly Error UserIdRequired = new(
        (string)"Posts.UserIdRequired",
        (string?)"User Id is required to create a post");

    public static readonly Error NullInput = new(
        (string)"Posts.NullInput",
        (string?)"Input can not be null");
}
namespace Modules.Posts.Application.Common.Errors;

public static class PostErrors
{
    public static readonly Error UserIdRequired = new(
        "Posts.UserIdRequired",
        "User Id is required to create a post");

    public static readonly Error NullInput = new(
        "Posts.NullInput",
        "Input can not be null");
}
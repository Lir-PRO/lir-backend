namespace Modules.Posts.Application.Common.Errors;

public static class CommentErrors
{
    public static readonly Error CommentIdRequired = new(
        "Comments.CommentIdRequired",
        "Comment Id is required");

    public static readonly Error NullInput = new(
        "Comments.NullInput",
        "Input can not be null");

    public static readonly Error NoContent = new(
        "Comments.NoInput",
        "Content can not be empty");

    public static readonly Error NotFound = new(
        "Comment.NotFound",
        "Comment not found");
}

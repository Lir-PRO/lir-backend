using Common;

namespace Modules.Posts.Application.Common.Errors;

public static class CommentErrors
{
    public static readonly Error CommentIdRequired = new(
        (string)"Comments.CommentIdRequired",
        (string?)"Comment Id is required");

    public static readonly Error NullInput = new(
        (string)"Comments.NullInput",
        (string?)"Input can not be null");

    public static readonly Error NoContent = new(
        (string)"Comments.NoInput",
        (string?)"Content can not be empty");

    public static readonly Error DeleteFailure = new(
        (string)"Comments.DeleteFailure",
        (string?)"Error occured deleting comment");

    public static readonly Error NotFound = new(
        (string)"Comment.NotFound",
        (string?)"Comment not found");
}

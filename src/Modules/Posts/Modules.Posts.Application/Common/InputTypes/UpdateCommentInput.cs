namespace Modules.Posts.Application.Common.InputTypes
{
    public class UpdateCommentInput
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
    }
}

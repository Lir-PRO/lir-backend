namespace Modules.Posts.Application.Common.InputTypes
{
    public class AddCommentInput
    {
        public string UserId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
    }
}

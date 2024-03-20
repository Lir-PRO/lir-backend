namespace Lir.Api.GraphQL.InputTypes
{
    public class UpdateCommentInput
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
    }
}

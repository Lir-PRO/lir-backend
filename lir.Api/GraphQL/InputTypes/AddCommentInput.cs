using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Lir.Api.GraphQL.InputTypes
{
    public class AddCommentInput
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
    }
}

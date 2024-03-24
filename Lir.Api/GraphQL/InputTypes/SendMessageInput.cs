namespace Lir.Api.GraphQL.InputTypes
{
    public class SendMessageInput
    {
        public Guid SenderId { get; set; } 
        public Guid ChatId { get; set; }
        public string Content { get; set; }
    }
}

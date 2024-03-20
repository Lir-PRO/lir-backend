namespace Lir.Api.GraphQL.InputTypes
{
    public class AddPostInput
    {
        public Guid UserId { get; set; }
        public string Caption { get; set; }
        public List<Guid> CategoryIds { get; set; }
        public List<ContentInput> ContentInputs { get; set; }
    }
}

namespace Modules.Posts.Application.Common.InputTypes
{
    public class UpdatePostInput
    {
        public Guid PostId { get; set; }
        public string Caption { get; set; }
        public List<Guid> CategoryIds { get; set; }
        public List<ContentInput> ContentInputs { get; set; }
    }
}

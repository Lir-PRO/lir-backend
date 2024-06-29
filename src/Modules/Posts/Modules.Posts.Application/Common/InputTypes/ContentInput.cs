using Modules.Posts.Domain.Enums;

namespace Modules.Posts.Application.Common.InputTypes
{
    public class ContentInput
    {
        public ContentType ContentType { get; set; }
        public string ContentBase64 { get; set; }
    }
}

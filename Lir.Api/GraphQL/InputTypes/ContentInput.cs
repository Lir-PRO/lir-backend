using Lir.Core.Enums;

namespace Lir.Api.GraphQL.InputTypes
{
    public class ContentInput
    {
        public ContentType ContentType { get; set; }
        public string ContentBase64 { get; set; }
    }
}

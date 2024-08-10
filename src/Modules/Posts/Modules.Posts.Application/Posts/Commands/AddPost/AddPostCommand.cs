using MediatR;
using Modules.Posts.Application.Common;
using Modules.Posts.Application.Common.InputTypes;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Posts.Commands.AddPost
{
    public record AddPostCommand(AddPostInput Input) : IRequest<Response<PostPayload>>;
}

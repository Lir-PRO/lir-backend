using Common;
using HotChocolate;
using MediatR;
using Modules.Posts.Application.Common;
using Modules.Posts.Application.Common.InputTypes;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Application.Posts.Commands.AddPost;
using Modules.Posts.Application.Posts.Commands.UpdatePost;

namespace Modules.Posts.Endpoints.GraphQL.Mutations;
public class PostMutation
{
    public async Task<Response<PostPayload>> AddPost(AddPostInput input, [Service] ISender mediatr)
    {
        return await mediatr.Send(new AddPostCommand(input));
    }

    public async Task<Response<PostPayload>> UpdatePost(UpdatePostInput input, [Service] ISender mediatr)
    {
        return await mediatr.Send(new UpdatePostCommand(input));
    }
}
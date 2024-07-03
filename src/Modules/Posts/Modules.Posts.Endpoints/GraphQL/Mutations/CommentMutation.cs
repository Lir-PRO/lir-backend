using HotChocolate;
using MediatR;
using Modules.Posts.Application.Comments.Commands.AddComment;
using Modules.Posts.Application.Common.InputTypes;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Endpoints.GraphQL.Mutations;

public class CommentMutation
{
    public async Task<CommentPayload> AddComment(AddCommentInput input, [Service] ISender mediatr)
    {
        return await mediatr.Send(new AddCommentCommand(input));
    }
}
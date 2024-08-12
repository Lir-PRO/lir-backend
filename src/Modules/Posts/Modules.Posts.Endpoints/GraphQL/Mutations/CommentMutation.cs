using Common;
using HotChocolate;
using MediatR;
using Modules.Posts.Application.Comments.Commands.AddComment;
using Modules.Posts.Application.Comments.Commands.DeleteComment;
using Modules.Posts.Application.Comments.Commands.UpdateComment;
using Modules.Posts.Application.Common;
using Modules.Posts.Application.Common.InputTypes;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Endpoints.GraphQL.Mutations;

public class CommentMutation
{
    public async Task<Response<CommentPayload>> AddComment(AddCommentInput input, [Service] ISender mediatr)
    {
        return await mediatr.Send(new AddCommentCommand(input));
    }

    public async Task<Response<bool>> DeleteComment(Guid id, [Service] ISender mediatr)
    {
        return await mediatr.Send(new DeleteCommentCommand(id));
    }

    public async Task<Response<CommentPayload>> UpdateComment(UpdateCommentInput input, [Service] ISender mediatr)
    {
        return await mediatr.Send(new UpdateCommentCommand(input));
    }
}
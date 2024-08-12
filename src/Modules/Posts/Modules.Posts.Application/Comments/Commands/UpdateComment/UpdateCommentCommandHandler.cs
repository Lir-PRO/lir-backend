using AutoMapper;
using Common;
using MediatR;
using Modules.Posts.Application.Common.Errors;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Comments.Commands.UpdateComment;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Response<CommentPayload>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<Response<CommentPayload>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        if (request.Input == null)
        {
            return Response<CommentPayload>.Failure(CommentErrors.NullInput);
        }

        if (request.Input.CommentId == Guid.Empty)
        {
            return Response<CommentPayload>.Failure(CommentErrors.CommentIdRequired);
        }

        var comment = await _commentRepository.GetByIdAsync(request.Input.CommentId);

        if (comment == null)
        {
            return Response<CommentPayload>.Failure(CommentErrors.NotFound);
        }

        if (string.IsNullOrWhiteSpace(request.Input.Content))
        {
            return Response<CommentPayload>.Failure(CommentErrors.NoContent);
        }

        comment.Content = request.Input.Content;
        await _commentRepository.UpdateAsync(comment.Id, comment, cancellationToken);
        
        var payload = _mapper.Map<CommentPayload>(comment);

        return Response<CommentPayload>.Success(payload);
    }
}
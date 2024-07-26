using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Comments.Commands.UpdateComment;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, CommentPayload>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<CommentPayload> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Input == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (request.Input.CommentId == Guid.Empty)
        {
            throw new ArgumentException("Invalid comment ID", nameof(request.Input.CommentId));
        }

        var comment = await _commentRepository.GetByIdAsync(request.Input.CommentId);

        {}
        if (comment == null)
        {
            throw new InvalidOperationException($"Comment with ID {request.Input.CommentId} does not exist.");
        }

        if (string.IsNullOrWhiteSpace(request.Input.Content))
        {
            throw new ArgumentException("Content cannot be null or whitespace.", nameof(request.Input.Content));
        }

        comment.Content = request.Input.Content;
        await _commentRepository.UpdateAsync(comment.Id, comment, cancellationToken);

        return _mapper.Map<CommentPayload>(comment);
    }
}
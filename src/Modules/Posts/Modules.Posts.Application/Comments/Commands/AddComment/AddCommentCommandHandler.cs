using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Comments.Commands.AddComment;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, CommentPayload>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public AddCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<CommentPayload> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Input.PostId == Guid.Empty || string.IsNullOrEmpty(request.Input.UserId))
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrEmpty(request.Input.Content))
        {
            throw new ArgumentException(nameof(request));
        }

        var comment = new Comment
        {
            UserId = request.Input.UserId,
            PostId = request.Input.PostId,
            Content = request.Input.Content
        };

        await _commentRepository.AddAsync(comment, cancellationToken);

        return _mapper.Map<CommentPayload>(comment);
    }
}
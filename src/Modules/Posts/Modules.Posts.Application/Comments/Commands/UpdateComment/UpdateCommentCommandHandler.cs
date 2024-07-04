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
        var comment = await _commentRepository.GetByIdAsync(request.Input.CommentId);

        comment.Content = request.Input.Content;
        await _commentRepository.UpdateAsync(comment.Id, comment, cancellationToken);

        return _mapper.Map<CommentPayload>(comment);
    }
}
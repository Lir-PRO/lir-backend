using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common;
using Modules.Posts.Application.Common.Errors;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Comments.Commands.DeleteComment;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Response<bool>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<Response<bool>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var payload = await _commentRepository.DeleteAsync(request.Id, cancellationToken);

        if (!payload)
        {
            return Response<bool>.Failure(CommentErrors.DeleteFailure);
        }

        return Response<bool>.Success(payload);
    }
}
using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Comments.Queries.GetCommentsByPostId;

public class GetCommentsByPostIdQueryHandler : IRequestHandler<GetCommentsByPostIdQuery, IQueryable<CommentPayload>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentsByPostIdQueryHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<IQueryable<CommentPayload>> Handle(GetCommentsByPostIdQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetCommentsByPostIdAsync(request.PostId);

        var result = new List<CommentPayload>();

        foreach (var comment in comments)
        {
            result.Add(_mapper.Map<CommentPayload>(comment));
        }

        return result.AsQueryable();
    }
}
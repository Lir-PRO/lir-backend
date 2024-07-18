using AutoMapper;
using MediatR;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Application.Subscription.Queries.GetSubscribersByUserId;

public class GetSubscribersByUserIdQueryHandler : IRequestHandler<GetSubscribersByUserIdQuery, IQueryable<UserPayload>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetSubscribersByUserIdQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IQueryable<UserPayload>> Handle(GetSubscribersByUserIdQuery request, CancellationToken cancellationToken)
    {
        var subscribers = await _userRepository.GetSubscribersByUserId(request.UserId);

        var result = new List<UserPayload>();

        foreach (var subscriber in subscribers)
        {
            result.Add(_mapper.Map<UserPayload>(subscriber));
        }

        return result.AsQueryable();
    }
}
using AutoMapper;
using MediatR;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Application.Subscription.Queries.GetSubscriptionsByUserId;

public class GetSubscriptionsByUserIdQueryHandler : IRequestHandler<GetSubscriptionsByUserIdQuery, IQueryable<UserPayload>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetSubscriptionsByUserIdQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IQueryable<UserPayload>> Handle(GetSubscriptionsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var subscriptions = await _userRepository.GetSubscriptionsByUserId(request.UserId);

        var result = new List<UserPayload>();

        foreach (var subscription in subscriptions)
        {
            result.Add(_mapper.Map<UserPayload>(subscription));
        }

        return result.AsQueryable();
    }
}
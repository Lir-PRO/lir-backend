using AutoMapper;
using MediatR;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Application.Users.Queries.GetUsersSubscriptions;

public class GetUsersSubscriptionsQueryHandler : IRequestHandler<GetUsersSubscriptionsQuery, IQueryable<UserPayload>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersSubscriptionsQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IQueryable<UserPayload>> Handle(GetUsersSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var subscriptions = await _userRepository.GetSubscriptionsByUserId(request.Id);

        var result = new List<UserPayload>();

        foreach (var subscription in subscriptions)
        {
            result.Add(_mapper.Map<UserPayload>(subscription));
        }

        return result.AsQueryable();
    }
}
using AutoMapper;
using MediatR;
using Modules.Users.Application.Common.Payload;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Application.Users.Queries.GetUserByUsername;

public class GetUsersSubscribersQueryHandler : IRequestHandler<GetUsersSubscribersQuery, IQueryable<UserPayload>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersSubscribersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IQueryable<UserPayload>> Handle(GetUsersSubscribersQuery request, CancellationToken cancellationToken)
    {
        var subscribers = await _userRepository.GetSubscribersByUserId(request.Id);

        var result = new List<UserPayload>();

        foreach (var subscriber in subscribers)
        {
            result.Add(_mapper.Map<UserPayload>(subscriber));
        }

        return result.AsQueryable();
    }
}
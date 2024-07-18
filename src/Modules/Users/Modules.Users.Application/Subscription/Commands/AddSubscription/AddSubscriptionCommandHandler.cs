using MediatR;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Application.Subscription.Commands.AddSubscription;

public class AddSubscriptionCommandHandler : IRequestHandler<AddSubscriptionCommand, bool>
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public AddSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<bool> Handle(AddSubscriptionCommand request, CancellationToken cancellationToken)
    { 
       return await _subscriptionRepository.AddSubscription(request.SubscriberId, request.UserId);
    }
}
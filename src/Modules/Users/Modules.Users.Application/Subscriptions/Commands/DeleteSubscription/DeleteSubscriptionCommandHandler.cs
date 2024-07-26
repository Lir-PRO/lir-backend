using MediatR;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Application.Subscriptions.Commands.DeleteSubscription;

public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, bool>
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public DeleteSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<bool> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        return await _subscriptionRepository.DeleteSubscription(request.SubscriberId, request.UserId);
    }
}
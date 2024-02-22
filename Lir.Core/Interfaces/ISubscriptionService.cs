using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lir.Core.Interfaces
{
    public interface ISubscriptionService
    {
        Task AddSubscription(Guid subscriberId, Guid userId);
        Task DeleteSubscription(Guid subscriberId, Guid userId);
    }
}

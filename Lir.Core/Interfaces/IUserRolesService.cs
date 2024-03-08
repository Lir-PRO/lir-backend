using Lir.Core.Models;

namespace Lir.Core.Interfaces
{
    public interface IUserRolesService : IEntityBaseRepository<UserRoles>
    {
       Task<IEnumerable<UserRoles>> GetByUserId(Guid userId);
    }
}

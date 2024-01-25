using AYweb.Domain.Common.Repositories;

namespace AYweb.Domain.Models.Permission.Repositories
{
    public interface IPermissionRepository : IRepository<Entities.Permission>
    {
        bool CheckPermission(long userId, long permissionId);
    }
}

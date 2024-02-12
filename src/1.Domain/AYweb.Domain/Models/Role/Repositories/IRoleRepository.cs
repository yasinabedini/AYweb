using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Permission.Entities;
using System.Net.Sockets;

namespace AYweb.Domain.Models.Role.Repositories
{
    public interface IRoleRepository : IRepository<Role.Entities.Role>
    {
        void AddPermissionToRole(long roleId, long permissionId);
        void DeletePermissionFromRole(long roleId, long permissionId);
        List<Permission.Entities.Permission> GetRolePermission(long roleId);
        void DeleteRolePermissions(long roleId);
    }
}

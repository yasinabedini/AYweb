using AYweb.Dal.Entities.Permission;
using AYweb.Dal.Entities.User;
using Microsoft.AspNetCore.Http;

namespace AYweb.Core.Services.Interfaces;

public interface IPermissionService
{
    #region Role
    string GetAuthonticatedUserUsername(HttpContext context);
    int GetAuthonticatedUserUserId(HttpContext context);
    bool CheckPermission(string username, int permissionId);
    List<Role> GetRoles();
    void CreateRole(Role role);
    void UpdateRole(Role role);
    Role GetRoleById(int id);
    void UpdateUserRoles(string username, List<int> RolesId);
    void DeleteRole(int id);
    #endregion

    #region Permission
    List<Permission> GetPermission();
    void AddPermissionToRole(int roleId, List<int> permissionIds);
    void UpdateRolePermissions(int roleId, List<int> permissionIds);
    List<Permission> GetPermissionByRole(int roleId);
    void AddRoleToUserRole(int roleId, int UserId);
    #endregion
}

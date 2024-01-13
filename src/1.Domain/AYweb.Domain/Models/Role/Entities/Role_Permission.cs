using AIPFramework.Entities;
using AYweb.Domain.Models.Permission.Entities;

namespace AYweb.Domain.Models.Role.Entities;
public class Role_Permission : Entity<long>
{
    #region Properties
    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    public bool IsDelete { get; set; }

    public Role Role { get; set; }

    public Permission.Entities.Permission Permission { get; set; }    
    #endregion

    #region Constructor And Factories
    private Role_Permission() { }
    public Role_Permission(int roleId, int permissionId)
    {
        RoleId = roleId;
        PermissionId = permissionId;
        CreateAt = DateTime.Now;
    }
    public static Role_Permission Create(int roleId, int permissionId)
    {
        return new Role_Permission(roleId, permissionId);
    }
    #endregion

    #region Common
    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void Delete()
    {
        IsDelete = true;
        Modified();
    } 
    #endregion
}

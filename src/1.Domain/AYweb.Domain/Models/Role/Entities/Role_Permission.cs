using AIPFramework.Entities;
using AYweb.Domain.Models.Permission.Entities;

namespace AYweb.Domain.Models.Role.Entities;
public class Role_Permission : Entity<long>
{
    #region Properties
    public long RoleId { get; set; }

    public long PermissionId { get; set; }
    

    public Role Role { get; set; }

    public Permission.Entities.Permission Permission { get; set; }    
    #endregion

    #region Constructor And Factories
    private Role_Permission() { }
    public Role_Permission(long roleId, long permissionId)
    {
        RoleId = roleId;
        PermissionId = permissionId;
        CreateAt = DateTime.Now;
    }
    public static Role_Permission Create(long roleId, long permissionId)
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

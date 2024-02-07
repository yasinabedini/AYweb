using AIPFramework.Entities;

namespace AYweb.Domain.Models.Role.Entities;

public class Role_Users : Entity<long>
{
    #region Properties
    public long RoleId { get; set; }
    public long UserId { get; set; }

    public Role Role { get; set; }
    public User.Entities.User User { get; set; }    
    #endregion

    #region Constructor And Factories
    private Role_Users() { }
    public Role_Users(long roleId, long userId)
    {
        RoleId = roleId;
        UserId = userId;
        CreateAt = DateTime.Now;
    }
    public static Role_Users Create(long roleId, long userId)
    {
        return new Role_Users(roleId, userId);
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

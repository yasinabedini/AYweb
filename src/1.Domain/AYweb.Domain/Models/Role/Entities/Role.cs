using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;

namespace AYweb.Domain.Models.Role.Entities;

public class Role : AggregateRoot
{
    #region Properties
    public Title Title { get;private set; }
    
    public List<Role_Permission> Permissions { get; set; }
    public List<Role_Users> Role_Users { get; set; }
    #endregion

    #region Constructor And Factories
    private Role() { }
    public Role(string title)
    {
        Title = new Title(title);
        CreateAt = DateTime.Now;
    }
    public static Role Create(string title)
    {
        return new Role(title);
    }
    #endregion

    #region Common

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void ChangeTitle(string title)
    {
        Title = new Title(title);
        Modified();
    }

    public void AddUserToRole(Role_Users user)
    {
        Role_Users.Add(user);
    }

    public void AddPermissionToRole(long permissionId)
    {
        Permissions.Add(new Role_Permission(Id,permissionId));
    }

    public void Delete()
    {
        IsDelete = true;
        Modified();
    }
    #endregion
}

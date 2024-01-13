using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Academy.Entities.Configs;
using AYweb.Domain.Models.Role.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Domain.Models.Role.Entities;

[EntityTypeConfiguration(typeof(RoleConfig))]
public class Role : AggregateRoot
{
    #region Properties
    public Title Title { get;private set; }

    public bool IsDelete { get; private set; }

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

    public void AddPermissionToRole(Role_Permission role_Permission)
    {
        Permissions.Add(role_Permission);
    }

    public void Delete()
    {
        IsDelete = true;
        Modified();
    }
    #endregion
}

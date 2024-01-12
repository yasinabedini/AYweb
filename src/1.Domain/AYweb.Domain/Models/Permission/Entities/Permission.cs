using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Academy.Entities.Configs;
using AYweb.Domain.Models.Permission.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Domain.Models.Permission.Entities;

[EntityTypeConfiguration(typeof(PermissionConfig))]
public class Permission : AggregateRoot
{
    #region Properties
    public Title Title { get; private set; }

    public int? ParentId { get; private set; }

    public Permission? Parent { get; private set; }

    public bool IsDelete { get; private set; }
    
    #endregion

    #region Constructor And Factories
    private Permission() { }
    public Permission(string title, int? parentId)
    {
        Title = new Title(title);
        ParentId = parentId;
        CreateAt = DateTime.Now;
    }
    public static Permission Create(string title, int? parentId)
    {
        return new Permission(title, parentId);
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
    }

    public void Delete()
    {
        IsDelete = true;
        Modified();
    }
    #endregion
}

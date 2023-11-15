using AYweb.Dal.Entities.Permission;
using System.ComponentModel.DataAnnotations;

namespace AYweb.Dal.Entities.User;

public class Role
{
    [Key]
    public int RoleId { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Title { get; set; }

    public bool IsDelete { get; set; }

    public List<RolePermission> RolePermissions { get; set; }
}

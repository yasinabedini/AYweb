using System.ComponentModel.DataAnnotations;

namespace AYweb.Dal.Entities.User;

public class UserRoles
{
    [Key]
    public int UR_Id { get; set; }
    public int RoleId { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }
    public Role Role { get; set; }

}

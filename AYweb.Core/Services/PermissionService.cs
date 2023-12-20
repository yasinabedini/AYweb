using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using AYweb.Dal.Context;
using AYweb.Dal.Entities.Permission;
using AYweb.Dal.Entities.User;

namespace AYweb.Core.Services;

public class PermissionService : IPermissionService
{
    private readonly AYWebDbContext _context;
    private readonly IUserService _service;

    public PermissionService(AYWebDbContext context, IUserService service)
    {
        _context = context;
        _service = service;
    }

    public string GetAuthonticatedUserUsername(HttpContext context)
    {
        var claimsIdentity = context.User.Identity as ClaimsIdentity;
        var username = claimsIdentity.Claims.First(t => t.Type == ClaimTypes.NameIdentifier).Value;
        return username;
    }

    public User GetAuthonticatedUser(HttpContext context)
    {
        return _context.Users.First(t => t.Username == GetAuthonticatedUserUsername(context));
    }

    public int GetAuthonticatedUserUserId(HttpContext context)
    {

        var claimsIdentity = context.User.Identity as ClaimsIdentity;
        var username = claimsIdentity.Claims.First(t => t.Type == ClaimTypes.NameIdentifier).Value;
        return _service.GetUserByUsername(username).UserId;
    }

    public bool CheckPermission(string username, int permissionId)
    {
        User user = _context.Users.FirstOrDefault(t => t.Username == username);
        List<int> roles = _context.User_Roles.Where(t => t.UserId == user.UserId).Select(t => t.RoleId).ToList();
        var permission = _context.RolePermissions.Where(u => u.PermissionId == permissionId).ToList();

        if (!roles.Any())
        {
            return false;
        }

        foreach (var role in roles)
        {
            if (permission.Any(t => t.RoleId == role))
            {
                return true;
            }
        }
        return false;
    }
    public List<Role> GetRoles()
    {
        return _context.Roles.ToList();
    }
    public List<Permission> GetPermission()
    {
        return _context.Permissions.ToList();
    }
    public void AddPermissionToRole(int roleId, List<int> permissionIds)
    {
        foreach (var permissionId in permissionIds)
        {
            _context.RolePermissions.Add(new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId
            });
        }
        _context.SaveChanges();
    }
    public void CreateRole(Role role)
    {
        _context.Roles.Add(role);
        _context.SaveChanges();
    }
    public List<Permission> GetPermissionByRole(int roleId)
    {
        List<int> permissionIds = _context.RolePermissions.Where(t => t.RoleId == roleId).Select(t => t.PermissionId).ToList();

        List<Permission> permissions = new List<Permission>();

        foreach (var permissionId in permissionIds)
        {
            permissions.Add(_context.Permissions.Find(permissionId));
        }
        return permissions;
    }
    public void UpdateRolePermissions(int roleId, List<int> permissionIds)
    {
        _context.RolePermissions.Where(t => t.RoleId == roleId).ToList().ForEach(r => _context.RolePermissions.Remove(r));
        _context.SaveChanges();
        foreach (var permissionId in permissionIds)
        {
            _context.RolePermissions.Add(new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId
            });
        }
        _context.SaveChanges();
    }
    public Role GetRoleById(int id)
    {
        return _context.Roles.Find(id);
    }
    public void UpdateRole(Role role)
    {
        _context.Roles.Update(role);
        _context.SaveChanges();
    }
    public void AddRoleToUserRole(int roleId, int UserId)
    {
        _context.User_Roles.Add(new UserRoles()
        {
            UserId = UserId,
            RoleId = roleId
        });
        _context.SaveChanges();
    }
    public void UpdateUserRoles(string username, List<int> RolesId)
    {
        User user = _service.GetUserByUsername(username);
        foreach (var item in _context.User_Roles.Where(t => t.UserId == user.UserId))
        {
            _context.Remove(item);
        }
        _context.SaveChanges();
        foreach (var item in RolesId)
        {
            _context.User_Roles.Add(new UserRoles
            {
                UserId = user.UserId,
                RoleId = item
            });
        }
        _context.SaveChanges();
    }
    public void DeleteRole(int id)
    {
        Role role = GetRoleById(id);
        role.IsDelete = true;
        _context.Update(role);
        _context.SaveChanges();
    }

  
}

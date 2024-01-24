﻿using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Plan.Repositories;
using AYweb.Domain.Models.Role.Entities;
using AYweb.Domain.Models.Role.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Role.Repositories;

public class RoleRepository : BaseRepository<Domain.Models.Role.Entities.Role>, IRoleRepository,IRolePermissionRepository
{
    private readonly AyWebDbContext _context;
    public RoleRepository(AyWebDbContext context) : base(context)
    {
        _context = context;
    }

    public void AddPermissionToRole(long roleId, long permissionId)
    {
        var role = GetById(roleId);
        role.AddPermissionToRole(permissionId);
        Update(role);
    }

    public void DeletePermissionFromRole(long roleId, long permissionId)
    {
        var permissionRole = _context.Role_Permissions.First(t => t.RoleId == roleId && t.PermissionId == permissionId);
        permissionRole.Delete();
        Update(permissionRole);
    }

    public void Add(Role_Permission entity)
    {
        _context.Role_Permissions.Add(entity);
    }

    public void Update(Role_Permission entity)
    {
        _context.Role_Permissions.Update(entity);
    }

    Role_Permission IRepository<Role_Permission>.GetById(long id)
    {
        return _context.Role_Permissions.Find(id);
    }

    List<Role_Permission> IRepository<Role_Permission>.GetList()
    {
        return _context.Role_Permissions.ToList();
    }
}

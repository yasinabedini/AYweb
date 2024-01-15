﻿using AYweb.Domain.Models.Plan.Repositories;
using AYweb.Domain.Models.Role.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Role.Repositories;

public class RoleRepository : BaseRepository<Domain.Models.Role.Entities.Role>, IRoleRepository
{    
    public RoleRepository(AyWebDbContext context) : base(context)
    {
    }
}

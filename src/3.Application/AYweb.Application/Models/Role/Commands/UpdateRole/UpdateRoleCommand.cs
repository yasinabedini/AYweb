﻿using AIPFramework.Commands;
using AYweb.Domain.Models.Role.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Commands.UpdateRole
{
    public class UpdateRoleCommand:ICommand
    {
        public long Id { get; set; }
        public required string Title { get; set; }
    }
}

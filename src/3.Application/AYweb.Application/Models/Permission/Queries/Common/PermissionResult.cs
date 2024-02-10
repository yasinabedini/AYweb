using AYweb.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Permission.Queries.Common
{
    public class PermissionResult
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public long? ParentId { get; set; }
        public PermissionResult? Parent { get;  set; }
    }
}

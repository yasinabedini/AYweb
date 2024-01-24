using AYweb.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Service.Queries.Common
{
    public class ServiceResult
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string Image { get; set; }

        public int? ParentId { get; set; }

    }
}

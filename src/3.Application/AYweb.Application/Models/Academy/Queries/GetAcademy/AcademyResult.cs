using AYweb.Application.Models.Permission.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Academy.Queries.GetAcademy
{
    public class AcademyResult
    {
        public required string Name { get; set; }
        public int TeamCount { get; set; }
        public int ProjectCount { get; set; }
    }
}

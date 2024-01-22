using AIPFramework.Queries;
using AYweb.Application.Models.Project.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Project.Queries.GetProject
{
    public class GetProjectQuery:IQuery<ProjectResult>
    {
        public long Id { get; set; }
    }
}

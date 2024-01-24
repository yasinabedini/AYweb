using AIPFramework.Queries;
using AYweb.Application.Models.Service.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Service.Queries.GetService
{
    public class GetServiceQuery:IQuery<ServiceResult>
    {
        public long Id { get; set; }
    }
}

using AIPFramework.Queries;
using AYweb.Application.Models.Order.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Queries.GetOrderOrderLines
{
    public class GetOrderOrderLinesQuery:IQuery<List<OrderLinesResult>>
    {
        public long Id { get; set; }
    }
}

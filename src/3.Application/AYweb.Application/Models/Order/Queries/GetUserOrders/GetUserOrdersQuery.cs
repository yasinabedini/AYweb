using AIPFramework.Queries;
using AYweb.Application.Models.Order.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Queries.GetUserOrders
{
    public class GetUserOrdersQuery:IQuery<List<OrderResult>>
    {
        public long UserId { get; set; }
    }
}

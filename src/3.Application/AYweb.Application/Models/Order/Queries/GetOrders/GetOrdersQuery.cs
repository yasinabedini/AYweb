using AIPFramework.Queries;
using AYweb.Application.Models.Order.Queries.Common;
using AYweb.Domain.Models.Order.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Queries.GetOrders
{
    public class GetOrdersQuery:PageQuery<PagedData<OrderResult>>
    {
    }
}

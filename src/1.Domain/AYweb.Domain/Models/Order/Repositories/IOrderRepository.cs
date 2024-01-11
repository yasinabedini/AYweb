using AYweb.Domain.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Order.Repositories
{
    public interface IOrderRepository : IRepository<Order.Entities.Order>
    {
    }
}

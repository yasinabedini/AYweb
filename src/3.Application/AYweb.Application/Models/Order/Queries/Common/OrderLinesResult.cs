using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Queries.Common
{
    public class OrderLinesResult
    {
        public long ProductId { get; private set; }

        public int Count { get; private set; }

        public int UnitPrice { get; private set; }

        public int SumPrice { get; private set; }

        public required Domain.Models.Product.Entities.Product Product { get; set; }
    }
}

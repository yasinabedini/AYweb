using AYweb.Application.Models.Product.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Queries.Common
{
    public class OrderLinesResult
    {
        public long ProductId { get;  set; }

        public int Count { get;  set; }

        public int UnitPrice { get;  set; }

        public int SumPrice { get;  set; }

        public required ProductResult Product { get; set; }
    }
}

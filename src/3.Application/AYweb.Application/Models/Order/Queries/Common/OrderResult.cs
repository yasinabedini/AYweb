using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Order.Entities;
using AYweb.Domain.Models.Order.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Queries.Common
{
    public class OrderResult
    {
        public long Id { get; set; }
        public required string OrderStatus { get; set; }

        public int EndPrice { get; set; }

        public required string Notes { get; set; }
        
        public long UserId { get; set; }

        public required List<OrderLinesResult> OrderLines { get; set; }

        public DateTime CreateAt { get; set; }

        public long TransactionId { get; set; }
    }
}

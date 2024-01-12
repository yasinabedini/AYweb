using AYweb.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Order.ValueObjects.Conversion
{
    public class OrderStatusConversion : ValueConverter<OrderStatus, string>
    {
        public OrderStatusConversion() : base(c => c.Value, c => OrderStatus.FromString(c)) { }
    }
}

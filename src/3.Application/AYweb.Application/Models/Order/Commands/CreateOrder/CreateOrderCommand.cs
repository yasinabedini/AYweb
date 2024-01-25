using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.CreateOrder
{
    public class CreateOrderCommand:ICommand<Domain.Models.Order.Entities.Order>
    {
        public long UserId { get; set; }
    }
}

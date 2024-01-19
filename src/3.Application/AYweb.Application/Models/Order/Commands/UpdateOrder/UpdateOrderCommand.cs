using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand:ICommand
    {
        public required Domain.Models.Order.Entities.Order Order { get; set; }
    }
}

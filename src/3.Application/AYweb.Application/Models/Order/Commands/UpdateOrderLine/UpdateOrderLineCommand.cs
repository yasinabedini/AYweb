using AIPFramework.Commands;
using AYweb.Domain.Models.Order.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.UpdateOrderLine
{
    public class UpdateOrderLineCommand : ICommand
    {
        public required OrderLine OrderLine { get; set; }
    }
}

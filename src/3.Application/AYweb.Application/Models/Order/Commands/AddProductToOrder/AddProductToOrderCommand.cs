using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.AddProductToOrder
{
    public class AddProductToOrderCommand:ICommand
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}

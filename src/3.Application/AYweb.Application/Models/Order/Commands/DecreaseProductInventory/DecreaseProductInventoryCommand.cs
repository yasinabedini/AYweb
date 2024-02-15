using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.DecreaseProductInventory
{
    public class DecreaseProductInventoryCommand:ICommand
    {
        public long OrderId { get; set; }
    }
}

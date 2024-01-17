using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.DecreaseInventory
{
    public class DecreaseInventoryCommand:ICommand
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }
}

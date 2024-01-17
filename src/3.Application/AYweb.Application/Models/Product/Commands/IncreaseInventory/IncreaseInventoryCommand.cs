using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.IncreaseInventory
{
    public class IncreaseInventoryCommand:ICommand
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }
}

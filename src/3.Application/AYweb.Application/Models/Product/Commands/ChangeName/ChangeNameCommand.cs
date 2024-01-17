using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.ChangeName
{
    public class ChangeNameCommand:ICommand
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}

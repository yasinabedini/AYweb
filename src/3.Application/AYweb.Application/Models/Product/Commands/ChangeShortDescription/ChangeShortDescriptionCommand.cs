using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.ChangeShortDescription
{
    public class ChangeShortDescriptionCommand:ICommand
    {
        public int Id { get; set; }
        public required string ShortDescription { get; set; }
    }
}

using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.ChangeMainDescription
{
    public class ChangeMainDescriptionCommand:ICommand
    {
        public int Id { get; set; }
        public required string MainDescription { get; set; }
    }
}

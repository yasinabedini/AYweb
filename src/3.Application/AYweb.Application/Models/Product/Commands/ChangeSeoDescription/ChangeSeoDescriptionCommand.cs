using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.ChangeSeoDescription
{
    public class ChangeSeoDescriptionCommand:ICommand
    {
        public int Id { get; set; }
        public required string SeoDescription { get; set; }
    }
}

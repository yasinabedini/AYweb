using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand:ICommand
    {
        public Domain.Models.Product.Entities.Product Product { get; set; }
    }
}

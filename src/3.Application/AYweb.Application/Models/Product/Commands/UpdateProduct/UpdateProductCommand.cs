using AIPFramework.Commands;
using AYweb.Application.Models.Product.Queries.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand:ICommand
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string ShortDescription { get; set; }

        public required string MainDescription { get; set; }

        public required string SeoDescription { get; set; }

        public int Price { get; set; }

        public IFormFile? Image { get; set; }

        public int DiscountedPercent { get; set; }

        public int Inventory { get; set; }

        public bool IsSpecial { get; set; }
        
    }
}

﻿using AIPFramework.Commands;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Gallery.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.CreateProduct
{
    public class CreateProductCommand : ICommand<long>
    {
        public required string Name { get; set; }

        public required string ShortDescription { get; set; }

        public required string MainDescription { get; set; }

        public required string SeoDescription { get; set; }

        public int Price { get; set; }

        public required IFormFile Image { get; set; }

        public int DiscountedPercent { get; set; }

        public int Inventory { get; set; }
        
        public bool IsSpecial { get; set; }
    }
}

﻿using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand:ICommand
    {
        public int Id { get; set; }
    }
}

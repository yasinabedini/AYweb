﻿using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.DeleteProductFeatures
{
    public class DeleteProductFeaturesCommand:ICommand
    {
        public long Id { get; set; }
    }
}

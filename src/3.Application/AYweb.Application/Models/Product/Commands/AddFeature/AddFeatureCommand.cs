using AIPFramework.Commands;
using AYweb.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.AddFeature
{
    public class AddFeatureCommand:ICommand
    {
        public required string Title { get;  set; }
        public required string Value { get;  set; }

        public long ProductId { get;  set; }


    }
}

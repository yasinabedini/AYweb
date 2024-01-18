using AIPFramework.Queries;
using AYweb.Application.Models.Product.Queries.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Queries.GetProduct
{
    public class GetProductQuery:IQuery<ProductResult>
    {
        public int Id { get; set; }
    }
}

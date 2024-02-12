using AIPFramework.Queries;
using AYweb.Application.Models.Product.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Queries.GetProductFeatures
{
    public class GetProductFeaturesQuery:IQuery<List<FeatureResult>>
    {
        public long Id { get; set; }
    }
}

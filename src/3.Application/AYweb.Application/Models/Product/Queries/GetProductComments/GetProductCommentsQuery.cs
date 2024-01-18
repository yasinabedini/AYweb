using AIPFramework.Queries;
using AYweb.Application.Models.Product.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Queries.GetProductComments
{
    public class GetProductCommentsQuery: PageQuery<PagedData<CommentResult>>
    {
    }
}

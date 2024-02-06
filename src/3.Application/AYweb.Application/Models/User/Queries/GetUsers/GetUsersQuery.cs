using AIPFramework.Queries;
using AYweb.Application.Models.User.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Queries.GetUsers
{
    public class GetUsersQuery : PageQuery<PagedData<UserResult>>
    {
        public required string Search { get; set; }
    }
}

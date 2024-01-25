using AIPFramework.Queries;
using AYweb.Application.Models.User.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Queries.GetUserByPhoneNumber
{
    public class GetUserByPhoneNumberQuery:IQuery<UserResult>
    {
        public required string PhoneNumber { get; set; }
    }
}

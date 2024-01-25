using AIPFramework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Queries.GetVerificationCode
{
    public class GetVerificationCodeQuery:IQuery<string>
    {
        public required string PhoneNumber{ get; set; }
    }
}

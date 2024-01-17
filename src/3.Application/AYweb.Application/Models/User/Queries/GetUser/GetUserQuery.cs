using AIPFramework.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Queries.GetUser
{
    public class GetUserQuery : IQuery<UserResult>
    {
        public int Id { get; set; }
    }
}

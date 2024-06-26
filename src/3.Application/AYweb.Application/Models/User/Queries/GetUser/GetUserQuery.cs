﻿using AIPFramework.Queries;
using AYweb.Application.Models.User.Queries.Common;
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
        public long Id { get; set; }
    }
}

﻿using AIPFramework.Queries;
using AYweb.Application.Models.User.Queries.Common;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.User.Queries.GetAllUserQuery
{
    public class GetAllUserQueryHandler : IQueryHandler<GetAllUserQuery, PagedData<UserResult>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetAllUserQueryHandler(IMapperAdapter mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<PagedData<UserResult>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new PagedData<UserResult>() {QueryResult = _mapper.Map<List<Domain.Models.User.Entities.User>,List<UserResult>>(_repository.GetList()) });
        }
    }
}

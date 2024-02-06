using AIPFramework.Queries;
using AutoMapper;
using AYweb.Application.Models.Transaction.Queries.Common;
using AYweb.Application.Models.User.Queries.Common;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.User.Queries.GetUsers
{
    public class GetUsersQueryHandler:IQueryHandler<GetUsersQuery,PagedData<UserResult>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetUsersQueryHandler(IUserRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PagedData<UserResult>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _repository.GetList();

            var userList = _mapper.Map<List<Domain.Models.User.Entities.User>, List<UserResult>>(users.Skip(request.SkipCount).Take(request.PageSize).ToList());

            return Task.FromResult(new PagedData<UserResult> { QueryResult = userList, PageNumber = request.PageNumber, PageSize = request.PageSize, TotalCount = users.Count });
        }
    }
}

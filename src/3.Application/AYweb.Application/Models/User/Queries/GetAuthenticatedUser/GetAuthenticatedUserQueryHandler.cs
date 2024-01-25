using AIPFramework.Queries;
using AYweb.Application.Models.User.Queries.Common;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.User.Queries.GetAuthenticatedUser
{
    public class GetAuthenticatedUserQueryHandler : IQueryHandler<GetAuthenticatedUserQuery, UserResult>
    {
        private readonly IUserRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetAuthenticatedUserQueryHandler(IUserRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<UserResult> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<Domain.Models.User.Entities.User,UserResult>(_repository.GetAuthenticatedUser()));
        }
    }
}

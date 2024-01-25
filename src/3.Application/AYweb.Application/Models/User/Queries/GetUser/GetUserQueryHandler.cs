using AIPFramework.Queries;
using AYweb.Application.Models.User.Queries.Common;
using AYweb.Domain.Models.User.Entities;
using AYweb.Domain.Models.User.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.User.Queries.GetUser
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, Domain.Models.User.Entities.User>
    {
        private readonly IUserRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetUserQueryHandler(IUserRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Domain.Models.User.Entities.User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var res = _repository.GetByIdWithGraph(request.Id);

            return res;
        }
    }
}

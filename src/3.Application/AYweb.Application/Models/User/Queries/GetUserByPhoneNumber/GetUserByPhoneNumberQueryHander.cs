using AIPFramework.Commands;
using AIPFramework.Queries;
using AYweb.Application.Models.User.Queries.Common;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.User.Queries.GetUserByPhoneNumber
{
    public class GetUserByPhoneNumberQueryHander : IQueryHandler<GetUserByPhoneNumberQuery, UserResult>
    {
        private readonly IMapperAdapter _mapper;
        private readonly IUserRepository _repository;

        public GetUserByPhoneNumberQueryHander(IUserRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<UserResult> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<Domain.Models.User.Entities.User, UserResult>(_repository.GetUSerByPhoneNumber(request.PhoneNumber)));
        }
    }
}

using AIPFramework.Queries;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Queries.GetAuthenticatedUser
{
    public class GetAuthenticatedUserQueryHandler : IQueryHandler<GetAuthenticatedUserQuery, Domain.Models.User.Entities.User>
    {
        private readonly IUserRepository _repository;

        public GetAuthenticatedUserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<Domain.Models.User.Entities.User> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetAuthenticatedUser());
        }
    }
}

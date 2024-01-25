using AIPFramework.Queries;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Queries.GetVerificationCode
{
    public class GetVerificationCodeQueryHandler : IQueryHandler<GetVerificationCodeQuery, string>
    {
        private readonly IUserRepository _repository;

        public GetVerificationCodeQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(GetVerificationCodeQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetUserVerificationCode(request.PhoneNumber));
        }
    }
}
